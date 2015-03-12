using BusinessLogicLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace SIP.Formas.Catalogos
{
    public partial class catTipoSubprograma : System.Web.UI.Page
    {
        private UnitOfWork uow;

        protected void Page_Load(object sender, EventArgs e)
        {
            uow = new UnitOfWork(Session["IdUser"].ToString());

            if (!IsPostBack)
            {
                BindGrid();
                BindCombos();
                ModoForma(false);
            }
        }



        #region metodos

        private void BindCombos()
        {

            ddlBeneficiarios.DataSource = uow.AperturaProgramaticaBeneficiarioBusinessLogic.Get().ToList();
            ddlBeneficiarios.DataValueField = "Id";
            ddlBeneficiarios.DataTextField = "Nombre";
            ddlBeneficiarios.DataBind();
            
            ddlUnidad.DataSource = uow.AperturaProgramaticaUnidadBusinessLogic.Get().ToList();
            ddlUnidad.DataValueField = "Id";
            ddlUnidad.DataTextField = "Nombre";
            ddlUnidad.DataBind();
 
        }
        private void BindGrid()
        {
            uow = new UnitOfWork(Session["IdUser"].ToString());

            int ejercicio = int.Parse(Session["EjercicioId"].ToString());

            int idPrograma = int.Parse(Request.QueryString["id"].ToString());

            this.grid.DataSource = uow.AperturaProgramaticaBusinessLogic.Get(p => p.EjercicioId == ejercicio && p.ParentId == idPrograma && p.Nivel == 3);
            this.grid.DataBind();


            AperturaProgramatica ap = uow.AperturaProgramaticaBusinessLogic.GetByID(idPrograma);
            this.txtTitulo.Text = ap.Parent.Clave + " - " + ap.Parent.Nombre + " >> " + ap.Clave + " - " + ap.Nombre + " >> Tipos de subprograma...";
            this.txtTituloBis.Text = ap.Parent.Clave + " - " + ap.Parent.Nombre + " >> " + ap.Clave + " - " + ap.Nombre + " >> Tipos de subprograma...";

        }

        private void ModoForma(bool modoCaptura)
        {

            this.divMsg.Style.Add("display", "none");
            this.divMsgSuccess.Style.Add("display", "none");

            if (modoCaptura)
            {
                this.divDatos.Style.Add("display", "none");
                this.divBtnNuevo.Style.Add("display", "none");
                this.divCaptura.Style.Add("display", "block");

            }
            else
            {
                this.divDatos.Style.Add("display", "block");
                this.divBtnNuevo.Style.Add("display", "block");
                this.divCaptura.Style.Add("display", "none");
            }

        }


        #endregion

        #region eventos
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            _Accion.Text = "Nuevo";
            ModoForma(true);

            txtClave.Value = string.Empty;
            txtDescripcion.Value = string.Empty;
        }

        protected void imgBtnEdit_Click(object sender, ImageClickEventArgs e)   
        {
            GridViewRow row = (GridViewRow)((ImageButton)sender).NamingContainer;
            _ElId.Text = grid.DataKeys[row.RowIndex].Values["Id"].ToString();

            AperturaProgramatica ap = uow.AperturaProgramaticaBusinessLogic.GetByID(int.Parse(_ElId.Text));
            txtClave.Value = ap.Clave;
            txtDescripcion.Value = ap.Nombre;
            ddlBeneficiarios.SelectedValue = ap.AperturaProgramaticaBeneficiarioId.ToString();
            ddlUnidad.SelectedValue = ap.AperturaProgramaticaUnidadId.ToString();

            _Accion.Text = "Modificar";
            ModoForma(true);
        }

        protected void imgBtnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow row = (GridViewRow)((ImageButton)sender).NamingContainer;
            _ElId.Text = grid.DataKeys[row.RowIndex].Values["Id"].ToString();


            if (_ElId.Text == "")
                return;
            AperturaProgramatica obj = uow.AperturaProgramaticaBusinessLogic.GetByID(int.Parse(_ElId.Text));



            uow.Errors.Clear();
            List<Obra> lista;
            lista = uow.ObraBusinessLogic.Get(p => p.AperturaProgramaticaId == obj.Id).ToList();




            if (lista.Count > 0)
                uow.Errors.Add("El registro no puede eliminarse porque ya ha sido usado en el sistema");



            //Se elimina el objeto
            if (uow.Errors.Count == 0)
            {
                uow.AperturaProgramaticaBusinessLogic.Delete(obj);
                uow.SaveChanges();
                BindGrid();
            }



            if (uow.Errors.Count == 0)
            {
                lblMensajeSuccess.Text = "El registro se ha eliminado correctamente";
                divMsg.Style.Add("display", "none");
                divMsgSuccess.Style.Add("display", "block");

            }

            else
            {
                string mensaje;

                mensaje = string.Empty;
                foreach (string cad in uow.Errors)
                    mensaje = mensaje + cad + "<br>";

                lblMensajes.Text = mensaje;
                divMsg.Style.Add("display", "block");
                divMsgSuccess.Style.Add("display", "none");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AperturaProgramatica obj;

            List<AperturaProgramatica> lista;

            String mensaje = "";
            int idPrograma = int.Parse(Request.QueryString["id"].ToString());


            if (_Accion.Text == "Nuevo")
                obj = new AperturaProgramatica();
            else
                obj = uow.AperturaProgramaticaBusinessLogic.GetByID(int.Parse(_ElId.Text));




            obj.EjercicioId = int.Parse(Session["EjercicioId"].ToString());
            obj.Clave = txtClave.Value;
            obj.Nombre = txtDescripcion.Value;
            obj.ParentId = idPrograma;
            obj.Nivel = 3;

            obj.AperturaProgramaticaBeneficiarioId = int.Parse(ddlBeneficiarios.SelectedValue);
            obj.AperturaProgramaticaUnidadId = int.Parse(ddlUnidad.SelectedValue);



            //validaciones
            uow.Errors.Clear();

            if (_Accion.Text == "Nuevo")
            {
                lista = uow.AperturaProgramaticaBusinessLogic.Get(p => p.EjercicioId == obj.EjercicioId && p.ParentId == obj.ParentId && p.Clave == obj.Clave).ToList();
                if (lista.Count > 0)
                    uow.Errors.Add("La Clave que capturo ya ha sido registrada anteriormente, verifique su información");

                lista = uow.AperturaProgramaticaBusinessLogic.Get(p => p.EjercicioId == obj.EjercicioId && p.ParentId == obj.ParentId && p.Nombre == obj.Nombre).ToList();
                if (lista.Count > 0)
                    uow.Errors.Add("La Descripción que capturo ya ha sido registrada anteriormente, verifique su información");

                uow.AperturaProgramaticaBusinessLogic.Insert(obj);
                mensaje = "El registro se ha  almacenado correctamente";

            }
            else
            { //update

                int xid;

                xid = int.Parse(_ElId.Text);

                lista = uow.AperturaProgramaticaBusinessLogic.Get(p => p.EjercicioId == obj.EjercicioId && p.ParentId == obj.ParentId && p.Clave == obj.Clave && p.Id != xid).ToList();
                if (lista.Count > 0)
                    uow.Errors.Add("La Clave que capturo ya ha sido registrada anteriormente, verifique su información");



                lista = uow.AperturaProgramaticaBusinessLogic.Get(p => p.EjercicioId == obj.EjercicioId && p.ParentId == obj.ParentId && p.Nombre == obj.Nombre && p.Id != xid).ToList();
                if (lista.Count > 0)
                    uow.Errors.Add("La Descripción que capturo ya ha sido registrada anteriormente, verifique su información");


                uow.AperturaProgramaticaBusinessLogic.Update(obj);


            }




            if (uow.Errors.Count == 0)
                uow.SaveChanges();



            if (uow.Errors.Count == 0)//Integrando el nuevo nodo en el arbol
            {
                BindGrid();
                ModoForma(false);

                lblMensajeSuccess.Text = "El registro se guardo correctamente";
                divMsgSuccess.Style.Add("display", "block");
                divMsg.Style.Add("display", "none");


            }
            else
            {
                mensaje = string.Empty;
                foreach (string cad in uow.Errors)
                    mensaje = mensaje + cad + "<br>";

                lblMensajes.Text = mensaje;
                divMsg.Style.Add("display", "block");
                divMsgSuccess.Style.Add("display", "none");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            ModoForma(false);

            
        }

        #endregion


    }
}