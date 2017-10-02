using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace moleQule.Face.Application
{
    public partial class NewsForm : moleQule.Face.NewsBaseForm
    {
        #region Business Methods

        public new const string ID = "NewsForm";
        public new static Type Type { get { return typeof(NewsForm); } }

        #endregion

        #region Factory Methods

        private NewsForm() : this(null, null) { }

        public NewsForm(List<string> notifications, Form parent)
            : base(notifications, parent)
        {
            InitializeComponent();
        }

        #endregion
    }
}

