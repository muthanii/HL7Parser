using System.Text.RegularExpressions;

public static class Functions 
{
  public static void HL7Check(string path)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    if (!path.EndsWith(".hl7"))
    { 
      Console.WriteLine("Invalid file type. Only .hl7 files are supported.", Console.ForegroundColor); Console.ResetColor();
      Environment.Exit(0);
    }
  }


  public static void Cleaning(string[] contents)
  {
    Console.ForegroundColor = ConsoleColor.Green;

    foreach (string content in contents)
    {
      if (content.Contains("PID"))
      {
        string result = content.Substring(10);
        Console.WriteLine($"Sample ID: {result}\n");
        Console.WriteLine("Parameter    Result    Unit       Ref. Range", Console.ForegroundColor); Console.ResetColor();
      }
    }
  }


  public static void GetData(string[] contents)
  {
    string namesPattern = @"\^\w{1,4}\-?\w{1,3}\#?\%?\^";
    string dataPatternResult = @"\|\|\d{1,3}.?\d{1,3}\|";
    string dataPatternUnit = @"\|(%|pg|fL|10\*\d\/u?d?L|g\/dL)\|";
    string dataPatternRefRange = @"\d{1,3}\.?\d{1,3}\-\d{1,3}\.?\d{1,3}";

    foreach (string content in contents)
    {
      Match namesMatch = Regex.Match(content, namesPattern);
      Match dataMatchResult = Regex.Match(content, dataPatternResult);
      Match dataMatchUnits = Regex.Match(content, dataPatternUnit);
      Match dataMatchRefRange = Regex.Match(content, dataPatternRefRange);

      if (namesMatch.Success)
      {
        if (dataMatchResult.Success)
        {
          if (dataMatchUnits.Success)
          {
            if (dataMatchRefRange.Success)
            {
              Console.WriteLine($"{namesMatch.Value.Replace("^", "").PadRight(12)} {dataMatchResult.Value.Replace("|", "").PadRight(10)}{dataMatchUnits.Value.Replace("|", "").PadRight(10)} {dataMatchRefRange.Value}");
            }
          }
        }
      }
    }
  }
}