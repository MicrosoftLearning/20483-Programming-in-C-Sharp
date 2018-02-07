:: TODO: Exercise 1: Task 1a: Create an asymmetric certificate
:: Open a command window running as Administrator and run this command file.
makecert -n "CN=Grades" -a sha1 -pe -r -sr LocalMachine -ss my -sky exchange