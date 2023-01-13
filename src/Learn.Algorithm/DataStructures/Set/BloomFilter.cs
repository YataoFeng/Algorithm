using System.Xml;

namespace Learn.Algorithm.DataStructures.Set;
public class BloomFilter
{
    private readonly HashSet<Int128> filter;

    public BloomFilter(int size)
    {
        filter = new (size);
    }

    public void AddKey(string key)
    {
        var hash = HashStingBitComputeUniqueValue(key);
        filter.Add(hash);
    }

    public bool KeyExists(string key)
    {
        var hash = HashStingBitComputeUniqueValue(key);
        return filter.Contains(hash);
    }
    /// <summary>
    /// 仅用于64位以下的小Key   2023/1/13 鹄
    /// 除超出位数以外 坚信不会产生碰撞
    /// </summary>
    /// <param name="key">建议字符长度为50为以内</param>
    /// <returns>返回是128位</returns>
    /// <exception cref="Exception">超出位数会出现数值碰撞</exception>
    private static Int128 HashStingBitComputeUniqueValue(string key)
    {
        Int128 total = 0;
        for (int i = 1; i <= key.Length; i++)
        {
            long charValue = key[i - 1];
            int index = key.Length - i;

            var charValueMaxBitLength = 64 - Convert.ToString(charValue, 2).Length;
            if (charValueMaxBitLength > index)
            {
                var result = (Int128)charValue << index;
                // Console.WriteLine($"{charValue} << {index} = {result}");
                total += result; 
                // 相加的时候也会出现炸弹 所以偷个懒 64位相加超过 到 128位
                // 如有需要 后面也可以解决
            }
            else
            {
                throw new Exception($"当前字符最大位移长度为{charValueMaxBitLength},需要位移的长度为{index}");
            }
        }
        return total;
    }





}
