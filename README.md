# HL7Parser
This is a parser for the [Swelab Lumi](https://boule.com/human-and-veterinary/swelab/swelab-lumi/) for it output which is in HL7 format. The main function of it is to convert the HL7 file into a more readable display for easy referencing. It's a C# console application and it takes the path of the file as an argument. Future updates would be to enter the HL7 text instead of the path of the output file. Example use is below: 
`.\HL7Parser.exe [PATH to HL7 file]`
It was done by implementing RegEx (Regular Expressions) using the System.Text.RegularExpressions library in C#. Below is a picture of a successful run.
![Example output using a random data from a Swelab Lumi HL7 file](img.jpg)
