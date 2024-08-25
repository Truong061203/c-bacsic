using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Xml;

namespace QuanLySinhVienHutech
{
    internal class QuanLystudent
    {
        static List<student> Lststudent = new List<student>();
        static int NextId = 1; 

        public void LoadFile(string fileName)
        {
            if(File.Exists(fileName))
            {
                try
                {
                    var lines = File.ReadAllLines(fileName);
                    foreach (var line in lines)
                    {
                        var pats = line.Split(',');
                     var sv = new student
                        {
                            Id = int.Parse(pats[0]),
                            Name = pats[1],
                            Age = int.Parse(pats[2]),
                            Gender = pats[3],
                            Math = Convert.ToDouble(pats[4]), // chuyển đổi về mảng 
                            Chemistry = Convert.ToDouble(pats[5]),
                            Physical = Convert.ToDouble(pats[6]),
                        };
                        sv.DiemTB();
                        sv.Xeploai();
                        Lststudent.Add(sv);
                        NextId = Math.Max(NextId, sv.Id + 1);
                    }
                }
                catch(Exception ex) 
                {
                    Console.WriteLine("kh saoo "+ex.Message);
                }
            }
           
        }
        public void SaveToFile(string fileName)
        {;
            var lines = Lststudent.Select(sv =>$"{ sv.Id},{ sv.Name},{ sv.Age},{ sv.Gender},{ sv.Math},{ sv.Chemistry},{ sv.Physical},{ sv.Averagescore},{ sv.HocLuc} ");
            File.WriteAllLines(fileName, lines);
            Console.WriteLine("Write list student success ");
        }


        public void AddStudent()
        {
            student sv = new student(); 
            sv.Id =NextId++;
            Console.Write("Name :");
            sv.Name = Convert.ToString(Console.ReadLine());

            Console.Write("Age: ");
            sv.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Gender: ");
            sv.Gender = Convert.ToString(Console.ReadLine());

            Console.Write("Nhap diem toan: ");
            sv.Math = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap diem ly: ");
            sv.Physical = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap diem hoa: ");
            sv.Chemistry = Convert.ToDouble(Console.ReadLine());

            sv.DiemTB();
            sv.Xeploai();
            Lststudent.Add(sv);
            Console.WriteLine("Add student success");
        }
        public void UpdateStudent()
        {
            Console.WriteLine("Nhap id can sua :");
            int id = Convert.ToInt32(Console.ReadLine());
            var up = Lststudent.FindIndex(s=>s.Id == id); // dung de kiem tra phan tu trong danh sach muon lay ra 
            if(up == -1)
            {
                Console.WriteLine("Danh sach kh ton tai");
                return; 
            }
           
            student sv = new student();
            
            Console.Write("Name :");
            sv.Name = Convert.ToString(Console.ReadLine());

            Console.Write("Age: ");
            sv.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Gender: ");
            sv.Gender = Convert.ToString(Console.ReadLine());

            Console.Write("Nhap diem toan: ");
            sv.Math = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap diem ly: ");
            sv.Physical = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap diem hoa: ");
            sv.Chemistry = Convert.ToDouble(Console.ReadLine());

            sv.DiemTB();
            sv.Xeploai();
            Lststudent[up] = sv; // caapj nhat danh sach thong qua mang 
            Console.WriteLine("update success");

        }
        public void DeletedId()
        {
            Console.WriteLine("Nhap id can xoa :"); 
            int id = int.Parse(Console.ReadLine());
            var sv = Lststudent.Find(s => s.Id == id);
            if (sv != null)
            {
                Lststudent.Remove(sv);
                Console.WriteLine("Delete success");
            }
            else
            {
                Console.WriteLine("Vui long nhap dung id can xoa ");
            }
        }

        public void SeachFindName()
        {
            Console.WriteLine("Moi nhap ten can tim "); 
            string name = Console.ReadLine().ToLower();
            bool find = false;
            foreach(var sv in Lststudent)
            {
                if (sv.Name.ToLower() == name)
                {
                    Console.WriteLine($" ID : {sv.Id} , Name :{sv.Name} ,Age {sv.Age} ,Sex {sv.Gender}, Toan :{sv.Math},Ly :{sv.Physical},Hoa :{sv.Chemistry}, Diem TB :{sv.Averagescore}, Hoc Luc :{sv.HocLuc}");
                    find = true;
                }
            }
            if (!find)
            {
                Console.WriteLine("kh co ten nay trong danh sach");
            }
        }

        public void seachStudentID()
        {
            Console.Write("Moi nhap id can tim :"); 
            int id = Convert.ToInt32(Console.ReadLine());
            var sv = Lststudent.Find(s => s.Id == id);
            if (sv != null)
            {
                Console.WriteLine($" ID : {sv.Id} , Name :{sv.Name} ,Age {sv.Age} ,Sex {sv.Gender}, Toan :{sv.Math},Ly :{sv.Physical},Hoa :{sv.Chemistry}, Diem TB :{sv.Averagescore}, Hoc Luc :{sv.HocLuc}");
            }
            else
            {
                Console.WriteLine("Moi nhap dung id sinh vien ");
            }
            //bool find = false;
            //foreach (var sv in Lststudent)
            //{
            //    if (sv.Id == id)
            //    {
            //        Console.WriteLine($" ID : {sv.Id} , Name :{sv.Name} ,Age {sv.Age} ,Sex {sv.Gender}, Toan :{sv.Math},Ly :{sv.Physical},Hoa :{sv.Chemistry}, Diem TB :{sv.Averagescore}, Hoc Luc :{sv.HocLuc}");
            //        find = true;
            //        break; 
            //    } 

            //}
            //if(!find)
            //{
            //    Console.WriteLine("kh co id nay trong danh sach "); 
            //}
        }


        public void SortedMark()
        {
            Lststudent = Lststudent.OrderBy(s => s.Averagescore).ToList();
           
            foreach (var sv in Lststudent)
            {

                Console.WriteLine($"{sv.Id},{sv.Name},{sv.Age},{sv.Gender},{sv.Math},{sv.Chemistry},{sv.Physical},{sv.Averagescore},{sv.HocLuc} ");
            }

        }
        public void SortedbyName()
        {
            Lststudent = Lststudent.OrderBy(s=>s.Name).ToList();
            foreach (var sv in Lststudent)
            {
                Console.WriteLine($"{sv.Id},{sv.Name},{sv.Age},{sv.Gender},{sv.Math},{sv.Chemistry},{sv.Physical},{sv.Averagescore},{sv.HocLuc} ");
            }
        }

        public void DisplayStudent()
        {

            foreach (var sv in Lststudent)
            {

                Console.WriteLine($"{sv.Id},{sv.Name},{sv.Age},{sv.Gender},{sv.Math},{sv.Chemistry},{sv.Physical},{sv.Averagescore},{sv.HocLuc} ");
            }
        }
    }

}
