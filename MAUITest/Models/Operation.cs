using System.Text;

namespace MAUITest.Models
{

    public class Operation
    {
        public Operation() { }

        public DateTime DateOperation { get; set; }
        public float Amount { get; set; }
        public string TypeOperation { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }


        public string DisplayDateTime
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(DateOperation.ToShortDateString())
                    .Append(", ")
                    .Append(DateOperation.Hour)
                    .Append(":")
                    .Append(DateOperation.Minute);
                return sb.ToString();
            }
        }
        public string DisplayAmount => $"${Amount}";
        public string DisplayComment
        {
            get
            {
                if (string.IsNullOrEmpty(Comment))
                    return "--";
                else
                    return Comment;
            }
        }
    }
}
