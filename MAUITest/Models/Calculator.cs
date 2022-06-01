namespace MAUITest.Models
{
    public class Calculator
    {
        public Calculator() { }

        //у меня возникли проблемы при извлечении данных с базы т.к. рекомендуют использовать плоскую модель
        //так бы можно было по типу операции определить нормально, а не вот так D:
        public float Sum(float account,IEnumerable<Operation> operations)
        {
            foreach(var operation in operations)
            {
                if(operation.TypeOperation == "Доход")
                    account += operation.Amount;
                else
                    account -= operation.Amount;
            }
            return account;
        }
    }
}
