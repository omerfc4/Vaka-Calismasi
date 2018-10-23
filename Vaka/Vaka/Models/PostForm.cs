using System.ComponentModel.DataAnnotations;

namespace Vaka.Models
{
    public class PostForm
    {
        [Display(Name = "Yüzeyin Sağ Üst Köşesi(5 5)")]
        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır.")]
        [RegularExpression(@"[0-9]{1,}\s[0-9]{1,}", ErrorMessage = "X Y formatında girilmelidir. X ve Y pozitif tamsayı olmak zorundadır.")]
        public string TopRightCorner { get; set; }

        [Display(Name = "Robotik Gezginin İlk Konumu(1 2 N)")]
        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır.")]
        [RegularExpression(@"[0-9]{1,}\s[0-9]{1,}\s[NWSE]{1}", ErrorMessage = "X Y N formatında girilmelidir. X ve Y pozitif tamsayı olmak zorundadır. N ise pusulada yer alan (N,W,S,E) karakterlerinden birisi olmak zorundadır.")]
        public string FirstRoboticTravellerLocation { get; set; }

        [Display(Name = "Nasadan Gelen Katar(LMLMLMLMM)")]
        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır.")]
        [RegularExpression("[LMR]{0,}", ErrorMessage = "Yalnızca L,M ve R karakterleri girilebilir.")]
        public string FirstArray { get; set; }

        [Display(Name = "2. Robotik Gezginin İlk Konumu(3 3 E)")]
        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır.")]
        [RegularExpression(@"[0-9]{1,}\s[0-9]{1,}\s[NWSE]{1}", ErrorMessage = "X Y N formatında girilmelidir. X ve Y pozitif tamsayı olmak zorundadır. N ise pusulada yer alan (N,W,S,E) karakterlerinden birisi olmak zorundadır.")]
        public string SecondRoboticTravellerLocation { get; set; }

        [Display(Name = "2. Nasadan Gelen Katar(MMRMMRMRRM)")]
        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır.")]
        [RegularExpression("[LMR]{0,}", ErrorMessage = "Yalnızca L,M ve R karakterleri girilebilir.")]
        public string SecondArray { get; set; }
    }
}