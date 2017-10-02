using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library.Application;

namespace moleQule.Face.Application
{
    public partial class BackupSelectForm : Skin01.SelectSkinForm
    {

        #region Bussiness Methods


        /// <summary>
        /// Función recursiva que va creando el árbol de copias de seguridad
        /// </summary>
        /// <param name="padre"></param>
        /// <param name="apartado"></param>
        private void SetBackupsValues(TreeNode padre, string[] backups)
        {
            if (padre == null)
            {
                while (Arbol_TV.Nodes.Count != 0)
                {
                    foreach (TreeNode t in Arbol_TV.Nodes)
                        Arbol_TV.Nodes.Remove(t);
                }
            }

            foreach (string item in backups)
            {
                if (item.EndsWith(".backup"))
                {
                    int pos = item.LastIndexOf("\\");
                    if (pos != -1)
                    {
                        string nombre = item.Substring(pos + 1);
                        nombre = nombre.Substring(0, nombre.Length - 7);
                        TreeNode nodo = new TreeNode(nombre);
                        nodo.NodeFont = new Font("Tahoma", (float)8.25, FontStyle.Regular);
                        nodo.ForeColor = System.Drawing.Color.Black;
                        nodo.Tag = item;

                        Arbol_TV.Nodes.Add(nodo);
                    }
                }
            }
        }

        protected override void SubmitAction()
        {
            _selected = Arbol_TV.SelectedNode.Tag;
            Close();
        }

        #endregion

        #region Factory Methods

        public BackupSelectForm()
            : base(true)
        {
            InitializeComponent();

            string directorio = AppController.Reg32GetServerPath() + Resources.Paths.BACKUPS;
            string [] archivos;

            if (Directory.Exists(directorio))
            {
                archivos = Directory.GetFiles(directorio);
                SetBackupsValues(null, archivos);
            }

            this.Text = Resources.Labels.RESTORE_BACKUP_TITLE;
        }

        #endregion

        #region Buttons

        #endregion

        #region Events

        #endregion


    }
}

