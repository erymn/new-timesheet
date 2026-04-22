using Sqids;

namespace RLZZ.Timesheet.Securities;

public static class StringExtensions
{
    extension(int id)
    {
        public string ToUniqueId()
        {
            var uniqueId = new SqidsEncoder<int>(new SqidsOptions()
            {
                Alphabet = "k3G7QAe51FCsPW92uEOyq4Bg6Sp8YzVTmnU0liwDdHXLajZrfxNhobJIRcMv7Hr4DXcolkKt",
                MinLength = 64
            });
            
            var encodedString = uniqueId.Encode(id);
            
            return encodedString;
        }    
    }
}