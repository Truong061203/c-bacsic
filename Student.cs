using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 
namespace QuanLySinhVienHutech
{
    internal class student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public double Math { get; set; }
        public double Physical { get; set; }
        public double Chemistry { get; set; }
        public double Averagescore { get; set; }
        public string HocLuc { get; set; }
        public student() { }
        public student(int id, string name, int age, string gender, double math, double physical, double chemistry, double averagescore, string hocLuc)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            Math = math;
            Physical = physical;
            Chemistry = chemistry;
            Averagescore = averagescore;
            HocLuc = hocLuc;
        }
        
        public void DiemTB()
        {
            Averagescore = (Math+Physical+Chemistry)/3; 
            
        }
        public void Xeploai()
        {
            if (Averagescore >= 8.0 && Averagescore <= 10)
            {
                HocLuc = "Gioi";
            }

            else if (Averagescore >= 6.5 && Averagescore <= 8.0)
            {
                HocLuc = "Kha";
            }
            else if (Averagescore >= 5.0 && Averagescore <= 6.5)
            {
                HocLuc = "Trung Binh";
            }
            if (Averagescore <= 5.0)
            {
                HocLuc = "Kem";
            }
        }
        
    }
}
