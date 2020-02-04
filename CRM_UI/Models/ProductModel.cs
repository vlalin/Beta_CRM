namespace CRM_UI.Models
{
    class ProductModel : BaseModel
    {
       
        private string _Measurements;
        public string Measurements
        {
            get { return _Measurements; }
            set { _Measurements = value; }
        }
        private string _CostPrice;
        public string CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }
        private string _Price;
        public string Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        private string _Weight;
        public string Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
        private string _Volume;
        public string Volume
        {
            get { return _Volume; }
            set { _Volume = value; }
        }
        private string _Url;
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        private string _InStock;
        public string InStock
        {
            get { return _InStock; }
            set { _InStock = value; }
        }
        private string _Total;
        public string Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        //public string vendorcode { get; set; }
        private string _Irrelevant;
        public string Irrelevant
        {
            get { return _Irrelevant; }
            set { _Irrelevant = value; }
        }

        private string _Marketplace;
        public string Marketplace 
        {
            get { return _Marketplace; }
            set { _Marketplace = value; }
        }

        private string _isDone;
        public string IsDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }
    }
}
