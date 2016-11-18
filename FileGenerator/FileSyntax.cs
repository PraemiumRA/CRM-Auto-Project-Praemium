using System.Text;

namespace FileGenerator
{
    /// <summary>
    /// Information of generating file
    /// </summary>
    class FileSyntax
    {
        public string name;
        public int id;
        public string extension;
        private StringBuilder builder;

        public FileSyntax(string name, int id, string extension) : this()
        {
            this.name = name;
            this.id = id;
            this.extension = extension;

        }

        public FileSyntax()
        {
            builder = new StringBuilder();
        }


        public override int GetHashCode()
        {
            return this.name.GetHashCode() + this.id.GetHashCode() + this.extension.GetHashCode();
        }
        
        public override bool Equals(object obj)
        {
            FileSyntax fileSyntax = obj as FileSyntax;
            if (fileSyntax == null)
                return false;

            return (fileSyntax.name.Equals(this.name)) && (fileSyntax.id == this.id) && (fileSyntax.extension.Equals(this.extension));
        }
        public bool Equals(FileSyntax fileSyntax)
        {
            return this.Equals((object)fileSyntax);
        }

        public override string ToString()
        {
            return (builder.Append(this.name)).Append(this.id).Append(this.extension).ToString();
        }
    }
}
