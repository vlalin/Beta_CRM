namespace CRM_UI.Models
{
    class BaseModel
    {
        private string _icon_path;

        public string icon_path
        {
            get { return _icon_path; }
            set { _icon_path = value; }
        }
        private string _vendorcode;
        public string vendorcode
        {
            get { return _vendorcode; }
            set { _vendorcode = value; }
        }

        //public Image image (string filename);
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
    }
}
