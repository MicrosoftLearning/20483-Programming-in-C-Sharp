using System;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Win32;
// TODO: 01: Bring the System.Reflection namespace into scope. 
using System.Reflection;

namespace FourthCoffee.TypeInspector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += (object sender, ResolveEventArgs args) =>
            {
                return System.Reflection.Assembly.ReflectionOnlyLoad(args.Name);
            };
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            var fileOpen = new OpenFileDialog();

            var result = fileOpen.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result.GetValueOrDefault())
            {
                this.pathBox.Text = fileOpen.FileName;
                this.LoadTypesFromAssembly();
            }
            else
            {
                MessageBox.Show("You must choose an assembly.", "Choose an Assembly");
            }
        }

        private void inspectButton_Click(object sender, RoutedEventArgs e)
        {
            var typeToGet = this.typesList.SelectedItem as string;

            if (typeToGet == null)
            {
                MessageBox.Show("You must select a type.", "No Type Selected");
                return;
            }

            var type = this.GetType(
                this.pathBox.Text,
                typeToGet);

            this.membersList.Items.Clear();

            this.RenderProperties(type.GetProperties());

            this.RenderMethods(type.GetMethods());
        }

        private void LoadTypesFromAssembly()
        {
            this.typesList.Items.Clear();

            var types = this.GetTypes(this.pathBox.Text);

            foreach (var type in types)
            {
                this.typesList.Items.Add(type.FullName);
            }

            if (types.Count() == 0)
            {
                MessageBox.Show("The assembly you have choosen does not include any types.", "No Types in Assembly");
            }
            else
            {
                this.typesList.SelectedIndex = 0;
            }
        }

        private void RenderMethods(MethodInfo[] methods)
        {
            foreach (var method in methods)
            {
                var signatureBuilder = new StringBuilder();

                signatureBuilder.Append("(method) ");

                if (method.IsPublic)
                    signatureBuilder.Append("public ");

                if (method.IsStatic)
                    signatureBuilder.Append("static ");

                signatureBuilder.AppendFormat("{0} ", method.ReturnType.Name);
                signatureBuilder.Append(method.Name);
                signatureBuilder.Append(this.GetParameters(method));

                this.membersList.Items.Add(signatureBuilder.ToString());
            }
        }

        private void RenderProperties(PropertyInfo[] properties)
        {
            foreach (var property in properties)
            {
                this.membersList.Items.Add(
                      string.Format(
                         "(property) {0} {1}",
                         property.DeclaringType.ToString(),
                         property.Name));
            }
        }

        private string GetParameters(MethodInfo method)
        {
            var parameters = method.GetParameters();

            var signatureBuilder = new StringBuilder();

            signatureBuilder.Append("(");

            var count = 1;
            var isFirst = true;
            foreach (var param in parameters)
            {
                if (!isFirst)
                    signatureBuilder.Append(", ");

                signatureBuilder.AppendFormat("{0} param{1}", param.ParameterType.ToString(), count);

                isFirst = false;

                count++;
            }

            signatureBuilder.Append(")");

            return signatureBuilder.ToString();
        }

        private Assembly GetAssembly(string path)
        {
            // TODO: 02: Create an Assembly object. 
            return Assembly.ReflectionOnlyLoadFrom(path);
        }

        private Type[] GetTypes(string path)
        {
            var assembly = this.GetAssembly(path);

            // TODO: 03: Get all the types from the current assembly. 
            return assembly.GetTypes();
        }

        private Type GetType(string path, string typeName)
        {
            var assembly = this.GetAssembly(path);

            // TODO: 04: Get a specific type from the current assembly. 
            return assembly.GetType(typeName);
        }
    }
}
