using static Functions;

string path = args[0]; HL7Check(path);

string[] data = File.ReadAllLines(path);

Cleaning(data);
GetData(data);