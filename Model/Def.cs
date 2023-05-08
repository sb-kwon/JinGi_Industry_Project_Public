using System.Collections.Generic;

namespace Model
{
    public class Def
    {
        public Def()
        {
            this.Columns = new List<string>();
        }
        //항목
        public List<string> Columns { get; set; }
        //테이블 명
        public string TableName { get; set; }
        //테이블 sql명
        public string TableLogical { get; set; }
        public string ValueLogical { get; set; }
        //선택된행
        public string SelectValue { get; set; }
    }
}