using System;

namespace XCI2TitleConverter
{
    class Utils
    {
        // Thanks to Falo@GBATemp
        public static byte[] getPatchedNpdmBytes(byte[] fileBytes, ulong targetTitleId)
        {
            int aci0RawOffset = BitConverter.ToInt32(fileBytes, 0x70);

            if (fileBytes[aci0RawOffset] != 0x41 ||
                fileBytes[aci0RawOffset + 1] != 0x43 ||
                fileBytes[aci0RawOffset + 2] != 0x49 ||
                fileBytes[aci0RawOffset + 3] != 0x30)
            {
                throw new Exception("Unable to decrypt NCA file, check your keyset! You should remove created files.");
            }

            byte[] TitleIdBytes = BitConverter.GetBytes(targetTitleId);

            Array.Copy(TitleIdBytes, 0, fileBytes, aci0RawOffset + 0x10, TitleIdBytes.Length);

            return fileBytes;
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
