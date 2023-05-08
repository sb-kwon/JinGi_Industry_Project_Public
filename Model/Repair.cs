namespace Model
{
    public class Repair
    {
        public Repair()
        {
        }
        //RepairHistory
        public int RepairHistoryNo { get; set; } //점검번호
        public string RepairName { get; set; } //점검명
        public string MachineName { get; set; } //장비명
        public string RepairHistoryMember { get; set; } //등록자
        public string RepairHistoryTime { get; set; } //등록시간
        public string RepairHistoryMemo { get; set; } //메모

        //RepairSituation
        public int RepairsituationNo { get; set; } //고유번호
        public string RepairsituationState { get; set; } //검사상태 (양호/불량)
        public string RepairsituationMember { get; set; } //검사자
        public string RepairsituationTime { get; set; } //검사시간
        public string RepairsituationDetails { get; set; } //수리내용
        public string RepairsituationMemo { get; set; } //메모

        //def_repair
        public int RepairNo { get; set; } //점검명 고유번호
        public bool check { get; set; }
    }
}
