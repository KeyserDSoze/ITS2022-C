namespace ITS2022_C.Library
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class IdentityCard
    {
        private string Id;
        private protected string Height;
        internal string Number;
        protected string Age;
        public string NameSurname;
       /// <summary>
       /// Controllo dell'identità e .....
       /// </summary>
        public bool Check()
        {
            Id = string.Empty;
            return true;
        }
        private protected void Something()
        {
            Id = string.Empty;
            Height = string.Empty;
            Number = string.Empty;
            Age = string.Empty;
            NameSurname = string.Empty;
        }
    }
}