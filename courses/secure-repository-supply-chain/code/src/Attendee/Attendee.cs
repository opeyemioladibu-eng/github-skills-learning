using System;
using System.IO;
using System.IO.Compression;

namespace Attendees
{

    public class Attendee
    {
        public void WriteToDirectory(ZipArchiveEntry entry, string destDirectory)
        {
            string normalizedDestDirectory = Path.GetFullPath(destDirectory);
            string destFileName = Path.GetFullPath(Path.Combine(normalizedDestDirectory, entry.FullName));

            if (!destFileName.StartsWith(normalizedDestDirectory + Path.DirectorySeparatorChar, StringComparison.Ordinal))
            {
                throw new InvalidOperationException("Archive entry points outside the destination directory.");
            }

            string destFileParent = Path.GetDirectoryName(destFileName);
            if (!string.IsNullOrEmpty(destFileParent))
            {
                Directory.CreateDirectory(destFileParent);
            }

            entry.ExtractToFile(destFileName);
        }
        
        public bool AddAttendee(string added)
        {
            if (added == "exists") {
                  return true;
            }
            return false;
        }      
    }
}