using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Grades.WPF.Services;
using System.Data.Services.Client;
using System.Windows.Threading;
using Microsoft.Win32;
using System.IO;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using Grades.WPF.GradesService.DataModel;
using Grades.Utilities;

namespace Grades.WPF
{
    public partial class StudentProfile : UserControl
    {
        #region Data Members
        private ServiceUtils _context;
        private FilterCriteria _filter;
        #endregion

        #region Event Members
        public event EventHandler Back;

        public event EventHandler StartBusy;
        public event EventHandler EndBusy;
        #endregion

        #region Constructor
        public StudentProfile()
        {
            InitializeComponent();

            _context = new ServiceUtils();
            _filter = new FilterCriteria();
        }
        #endregion

        #region Refresh
        private void InitRefresh()
        {
            btnBack.Visibility = (SessionContext.Role == "Teacher") ? Visibility.Visible : Visibility.Collapsed;
            profileView.Visibility = (SessionContext.Role != "Teacher") ? Visibility.Visible : Visibility.Collapsed;
            separatorVertical.Visibility = (SessionContext.Role != "Teacher") ? Visibility.Visible : Visibility.Collapsed;
            profileEdit.Visibility = (SessionContext.Role == "Teacher") ? Visibility.Visible : Visibility.Collapsed;
            listChild.Visibility = (SessionContext.Role == "Parent") ? Visibility.Visible : Visibility.Collapsed;
            txtAddGrade.Visibility = (SessionContext.Role == "Teacher") ? Visibility.Visible : Visibility.Collapsed;

            cbFilterDate.IsChecked = false;
            cbFilterSubject.IsChecked = false;

            _filter.CurrentSubject = ServiceUtils.Subjects[0];
            _filter.StartDate = DateTime.Now;
            _filter.EndDate = DateTime.Now;
            formSearch.DataContext = _filter;

            txtError.Visibility = Visibility.Collapsed;

            flipControl.ToFront();
        }

        public async void Refresh(string studentid)
        {
            InitRefresh();

            try
            {
                StartBusyEvent();

                // Get the details of the student
                var student = await _context.GetStudent(studentid);

                // Update the display with the details and grades of the student
                await DisplayStudentDetailsAndGrades(student);

                // If the current user is a parent, fetch the names of any other children and display them
                if (SessionContext.CurrentParent != null)
                {
                    await _context.GetStudentsByParent(SessionContext.UserName, OnGetStudentsByParentComplete);
                }
            }
            finally
            {
                EndBusyEvent();
            }
        }

        public async void Refresh(string firstname, string lastname)
        {
            InitRefresh();

            try
            {
                StartBusyEvent();

                var student = await _context.GetStudent(firstname, lastname);
                await DisplayStudentDetailsAndGrades(student);

                if (SessionContext.CurrentParent != null)
                {
                    await _context.GetStudentsByParent(SessionContext.UserName, OnGetStudentsByParentComplete);
                }
            }
            finally
            {
                EndBusyEvent();
            }
        }
        #endregion

        #region Events
        private void StartBusyEvent()
        {
            if (StartBusy != null)
                StartBusy(this, new EventArgs());
        }

        private void EndBusyEvent()
        {
            if (EndBusy != null)
                EndBusy(this, new EventArgs());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (SessionContext.Role != "Teacher")
                return;

            if (Back != null)
                Back(sender, e);
        }

        private void Child_Click(object sender, MouseButtonEventArgs e)
        {
            LocalStudent child = (sender as TextBlock).Tag as LocalStudent;
            Refresh(child.FirstName, child.LastName);
            SessionContext.CurrentStudent = child;
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            LocalGrade grade = (sender as GrungeButton).Tag as LocalGrade;

            Grid parentGrid = (sender as GrungeButton).Parent as Grid;
            DateTime dt = (parentGrid.Children[0] as DatePicker).SelectedDate.Value;

            ServiceUtils utils = new ServiceUtils();
            await utils.UpdateGrade(grade.Record);
        }

        private void Flip_Click(object sender, MouseButtonEventArgs e)
        {
            if ((sender as Grid).Tag.ToString() == "Front")
                flipControl.ToFront();
            else
                flipControl.ToBack();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            bool dateFilter = false;
            bool subjectFilter = false;

            if (cbFilterDate.IsChecked == false && cbFilterSubject.IsChecked == false)
            {
                txtError.Visibility = Visibility.Collapsed;
                ResetGrades();
                flipControl.ToFront();
                return;
            }

            if (cbFilterDate.IsChecked == true)
            {
                if (_filter.StartDate != null && _filter.EndDate != null)
                {
                    if (_filter.StartDate <= _filter.EndDate)
                        dateFilter = true;
                    else
                    {
                        txtError.Text = "Invalid Date Range.  Start date must be before End date.";
                        txtError.Visibility = Visibility.Visible;
                        return;
                    }
                }
                else
                {
                    txtError.Text = "Invalid Date(s).  Please select a start and end date.";
                    txtError.Visibility = Visibility.Visible;
                    return;
                }
            }

            txtError.Visibility = Visibility.Collapsed;

            if (cbFilterSubject.IsChecked == true)
                subjectFilter = true;

            if (dateFilter || subjectFilter)
            {
                if (dateFilter && subjectFilter)
                    FilterGrades(_filter.StartDate, _filter.EndDate, _filter.CurrentSubject.Name);
                else if (dateFilter)
                    FilterGrades(_filter.StartDate, _filter.EndDate, String.Empty);
                else
                    FilterGrades(null, null, _filter.CurrentSubject.Name);

                flipControl.ToFront();
            }
        }

        private void FilterSubject_Checked(object sender, RoutedEventArgs e)
        {
            listSubject.Init();
        }

        private void StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 1)
            {
                dpEndDate.DisplayDateStart = null;
                return;
            }

            dpEndDate.DisplayDateStart = (DateTime)e.AddedItems[0];
        }

        private void AddGrade_Click(object sender, MouseButtonEventArgs e)
        {
            AddGradeDialog dialog = new AddGradeDialog();
            dialog.Closed += new EventHandler(dialog_Closed);
            dialog.ShowDialog();
        }

        // Generate the grades report for the currently selected student
        private void SaveReport_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Use a SaveFileDiaolog to prompt the user for a filename to save the report as (must be a Word document)
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Word documents|*.docx";

                // Set the default filename to Grades.txt
                dialog.FileName = "Grades";
                dialog.DefaultExt = ".docx";

                // Display the dialog and get a filename from the user
                Nullable<bool> result = dialog.ShowDialog();

                // If the user selected a file, then generate the report
                if (result.HasValue && result.Value)
                {
                    try
                    {
                        // Generate the report by using a seperate task
                        Task.Run(() => GenerateStudentReport(SessionContext.CurrentStudent, dialog.FileName));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error generating report", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Generating Report", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void dialog_Closed(object sender, EventArgs e)
        {
            // Find the new set of grades for the currently displayed student (including any new and updated grades resulting from the dialog)
            var grades = await _context.GetGradesByStudent((studentPhoto.DataContext as LocalStudent).Record.UserId);

            // Display the new set of grades
            DisplayGrades(grades);
        }
        #endregion

        #region Filter
        private void RefreshGradeVisibility()
        {
            List<LocalGrade> grades = studentDetails.DataContext as List<LocalGrade>;
            if (grades == null || grades.Count == 0)
            {
                txtNoGrades.Visibility = Visibility.Visible;
                gridProfile.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtNoGrades.Visibility = Visibility.Collapsed;
                gridProfile.Visibility = Visibility.Visible;
            }
        }

        private void ResetGrades()
        {
            ListColorConverter.Reset();
            studentDetails.DataContext = null;
            studentDetails.DataContext = SessionContext.CurrentGrades;
            RefreshGradeVisibility();
        }

        private void FilterGrades(DateTime? startDate, DateTime? endDate, string subject)
        {
            if (SessionContext.CurrentGrades == null || SessionContext.CurrentGrades.Count == 0)
                return;

            if (!startDate.HasValue && !endDate.HasValue && subject == String.Empty)
                ResetGrades();
            else
            {
                List<LocalGrade> grades = null;

                if (startDate.HasValue && subject != String.Empty)
                {
                    // Both filters
                    grades = SessionContext.CurrentGrades.Where(g => g.AssessmentDate >= startDate && g.AssessmentDate < endDate && g.SubjectName == subject).ToList();
                }
                else if (startDate.HasValue && subject == String.Empty)
                {
                    // Date only
                    grades = SessionContext.CurrentGrades.Where(g => g.AssessmentDate >= startDate && g.AssessmentDate < endDate).ToList();
                }
                else if (!startDate.HasValue && subject != String.Empty)
                {
                    // subject only
                    grades = SessionContext.CurrentGrades.Where(g => g.SubjectName == subject).ToList();
                }

                if (grades != null)
                {
                    ListColorConverter.Reset();
                    studentDetails.DataContext = grades;
                    RefreshGradeVisibility();
                }
            }
        }
        #endregion

        #region Callbacks
        // Display the names of the students for a parent
        private void OnGetStudentsByParentComplete(IEnumerable<Student> students)
        {
            try
            {
                // Convert the list of students from the format provided by the dataservice to the format displayed by the application
                List<LocalStudent> studentList = new List<LocalStudent>();
                foreach (Student s in students)
                {
                    LocalStudent child = new LocalStudent() { Record = s };
                    studentList.Add(child);
                }

                // Use databinding to display the student names
                this.Dispatcher.Invoke(() => { listChild.ItemsSource = studentList; });
            }
            catch (DataServiceQueryException ex)
            {
                MessageBox.Show(String.Format("Error: {0} - {1}",
                    ex.Response.StatusCode.ToString(), ex.Response.Error.Message));
            }
        }
        #endregion

        #region Utility and Helper Methods

        // Update the display with the details of the specified student and retrieve the grades for this student
        private async Task DisplayStudentDetailsAndGrades(Student student)
        {
            try
            {
                LocalStudent child = new LocalStudent()
                {
                    Record = student
                };

                // Display the photo for ths stdudent by using databinding
                studentPhoto.DataContext = child;

                // Find the grades for the student and display them
                var grades = await _context.GetGradesByStudent(student.UserId);
                DisplayGrades(grades);
            }
            catch (DataServiceQueryException ex)
            {
                MessageBox.Show(String.Format("Error: {0} - {1}",
                    ex.Response.StatusCode.ToString(), ex.Response.Error.Message));
            }
            catch (Exception e)
            {
                MessageBox.Show(String.Format("Error: {0} - {1}", e.Message));
            }
        }

        // Display a list of grades
        private void DisplayGrades(IEnumerable<Grade> gradeResults)
        {
            try
            {
                // Convert the list of grades from the format provided by the dataservice to the format displayed by the application
                List<LocalGrade> grades = new List<LocalGrade>();

                foreach (Grade g in gradeResults)
                {
                    LocalGrade grade = new LocalGrade();
                    grade.Record = g;
                    grade.Record.Subject = ServiceUtils.GetSubject(g.SubjectId);
                    grades.Add(grade);
                }

                // Display the grades
                SessionContext.CurrentGrades = grades;
                ResetGrades();
            }
            catch (DataServiceQueryException ex)
            {
                MessageBox.Show(String.Format("Error: {0} - {1}",
                    ex.Response.StatusCode.ToString(), ex.Response.Error.Message));
            }
        }

        // Format a list of grades as an XML document and write it to a MemoryStream
        private MemoryStream FormatAsXMLStream(List<LocalGrade> grades)
        {
            // Save the XML document to a MemoryStream by using an XmlWriter
            MemoryStream ms = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(ms);

            // The document root has the format <Grades Student="Eric Gruber">
            writer.WriteStartDocument();
            writer.WriteStartElement("Grades");
            writer.WriteAttributeString("Student", String.Format("{0} {1}", SessionContext.CurrentStudent.FirstName, SessionContext.CurrentStudent.LastName));

            // Format the grades for the student and add them as child elements of the root node
            // Grade elements have the format <Grade Date="01/01/2012" Subject="Math" Assessment="A-" Comments="Good" />
            foreach (LocalGrade grade in grades)
            {
                writer.WriteStartElement("Grade");
                writer.WriteAttributeString("Date", grade.AssessmentDate.ToString("d"));
                writer.WriteAttributeString("Subject", grade.SubjectName);
                writer.WriteAttributeString("Assessment", grade.Assessment);
                writer.WriteAttributeString("Comments", grade.Comments);
                writer.WriteEndElement();
            }

            // Finish the XML document with the appropriate end elements
            writer.WriteEndElement();
            writer.WriteEndDocument();

            // Flush the XmlWriter and close it to ensure that all the data is written to the MemoryStream
            writer.Flush();
            writer.Close();

            // The MemoryStream now contains the formatted data
            // Reset the MemoryStream so it can be read from the start and then return it
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        // Format the XML data in the stream as a neatly constructed string
        private string FormatXMLData(Stream stream)
        {
            // Use a StringBuilder to construct the string
            StringBuilder builder = new StringBuilder();

            // Use an XmlTextReader to read the XML data from the stream
            XmlTextReader reader = new XmlTextReader(stream);

            // Read and process the XML data a node at a time
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.XmlDeclaration:
                        // The node is an XML declaration such as <?xml version='1.0'>
                        builder.Append(String.Format("<?{0} {1}>\n", reader.Name, reader.Value));
                        break;

                    case XmlNodeType.Element:
                        // The node is an element (enclosed between '<' and '/>')
                        builder.Append(String.Format("<{0}", reader.Name));
                        if (reader.HasAttributes)
                        {
                            // Output each of the attributes of the element in the form "name='value'"
                            while (reader.MoveToNextAttribute())
                            {
                                builder.Append(String.Format(" {0}='{1}'", reader.Name, reader.Value));
                            }
                        }
                        builder.Append(">\n");
                        break;

                    case XmlNodeType.EndElement:
                        // The node is the closing tag at the end of an element
                        builder.Append(String.Format("</{0}>", reader.Name));
                        break;
                }
            }

            // Reset the stream
            stream.Seek(0, SeekOrigin.Begin);

            // Return the string containing the formatted data
            return builder.ToString();
        }

        // Generate a student grade report as a Word document.
        public void GenerateStudentReport(LocalStudent studentData, string reportPath)
        {
            WordWrapper wrapper = new WordWrapper();

            // Create a new Word document in memory
            wrapper.CreateBlankDocument();

            // Add a heading to the document
            wrapper.AppendHeading(String.Format("Grade Report: {0} {1}", studentData.FirstName, studentData.LastName));
            wrapper.InsertCarriageReturn();
            wrapper.InsertCarriageReturn();

            // Output the details of each grade for the student
            foreach (var grade in SessionContext.CurrentGrades)
            {
                wrapper.AppendText(grade.SubjectName, true, true);
                wrapper.InsertCarriageReturn();
                wrapper.AppendText("Assessment: " + grade.Assessment, false, false);
                wrapper.InsertCarriageReturn();
                wrapper.AppendText("Date: " + grade.AssessmentDateString, false, false);
                wrapper.InsertCarriageReturn();
                wrapper.AppendText("Comment: " + grade.Comments, false, false);
                wrapper.InsertCarriageReturn();
                wrapper.InsertCarriageReturn();
            }

            // Save the Word document
            wrapper.SaveAs(reportPath);
        }
        #endregion
    }
}
