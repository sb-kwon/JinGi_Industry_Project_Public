using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Material
{
    // 자재 정보(자체 제작)(창고) 
    public class MaterialsSemi
    {
        public MaterialsSemi() { Materialssemicnt = 0; }
        // 반재품 고유번호 
        public int Materialssemino { get; set; }
        // 반재품 명 
        public string Materialsseminame { get; set; }
        // MaterialsSemiCnt 
        public int Materialssemicnt { get; set; }
        // dump1 
        public string Materialssemivalue { get; set; }

        public List<string[]> Materialssemivalue2 { get; set; }  //이름, 수량, 고유번호 (고유번호는 삽입해야함) //
      
    }
}
