namespace amitChat11.GeneratorModule;

public class ChecksumModule
{
    public static List<byte> Checksum(List<byte> collection)
    {
        long checksum = 0;
        foreach (byte b in collection)
        {
            checksum += b;
        }
        
        List<byte> byteList=new List<byte>(BitConverter.GetBytes(checksum));

        int numByte = 0;
        foreach (byte b in byteList)
        {
            numByte++;
        }

        for (int i = numByte; i < 8; i++)
        {
            byteList.Add((byte)('!'));
        }

        return byteList;
    }
}