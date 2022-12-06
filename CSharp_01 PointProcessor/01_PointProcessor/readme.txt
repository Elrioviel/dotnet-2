
This Console App can read from console, or from files.
When reading from console, the users enters two decimals seperated by "," as point's coordinations.
The user can enter coordinations from console as much as they want.
When the user is done entering coordinations, he/she can enter an empty line to get the results.
When reading from files, the user will be asked to specify how many files they wish to process.
This app reads those files and gets all coordinations from every line.

Testing:
If there is an empty line in a file, the app will ignore it and continue to read the next lines.
If the file is empty, the app won't display any coordinations.
If there are three coordinations/letters in one line, we get an exception (System.FormatException: 'Input string was not in a correct format.')
If there's only one coordination, it will assign 0 as X and Y coordinations and will continue reading the following lines/files.