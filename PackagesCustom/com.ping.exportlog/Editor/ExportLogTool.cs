using System;
using System.IO;
using System.Text;
using UnityEditor;

namespace ConsoleTiny
{
    public class ExportLogTool
    {
        [MenuItem("Console Tiny/Export Log")]
        public static void ExportLog()
        {
            string filePath = EditorUtility.SaveFilePanel("Export Log", "",
                "Console Log " + string.Format("{0:HHmm}", DateTime.Now) + ".txt", "txt");
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            var totalCount = LogEntries.StartGettingEntries();
            for (int i = 0; i < totalCount; i++)
            {
                var entry = new LogEntry();
                LogEntries.GetEntryInternal(i, entry);
                sb.Append(entry.message);
            }


            LogEntries.EndGettingEntries();

            File.WriteAllText(filePath, sb.ToString());
        }
    }
}