using DataAccessLayer;
using DataAccessLayer.Models;
using BusinessLogicLayer;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIP.Formas.Catalogos
{
    public partial class catConceptosDeObra : System.Web.UI.Page
    {
        private UnitOfWork uow;


        protected void Page_Load(object sender, EventArgs e)
        {
            uow = new UnitOfWork(Session["IdUser"].ToString());

            cargarGruposConceptos();
        }


        private void cargarGruposConceptos()
        {

            int ejercicio = int.Parse(Session["EjercicioId"].ToString());

            
            List<GruposConceptosDeObra> listaPadres = uow.GruposConceptosDeObraBL.Get(p => p.EjercicioId == ejercicio && p.Nivel == 1).ToList();
            List<GruposConceptosDeObra> listaHijos;

            int i = 0;
            foreach (GruposConceptosDeObra padre in listaPadres)
            {
                i++;


                System.Web.UI.HtmlControls.HtmlGenericControl divPanel = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                System.Web.UI.HtmlControls.HtmlGenericControl divPanelHeading = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                System.Web.UI.HtmlControls.HtmlGenericControl divPanelCollapse = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                System.Web.UI.HtmlControls.HtmlGenericControl divPanelBody = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");

                System.Web.UI.HtmlControls.HtmlGenericControl h4 = new System.Web.UI.HtmlControls.HtmlGenericControl("H4");
                System.Web.UI.HtmlControls.HtmlGenericControl a = new System.Web.UI.HtmlControls.HtmlGenericControl("A");

                System.Web.UI.HtmlControls.HtmlGenericControl p = new System.Web.UI.HtmlControls.HtmlGenericControl("P");

                System.Web.UI.HtmlControls.HtmlGenericControl addConcepto = new System.Web.UI.HtmlControls.HtmlGenericControl("A");
                
                //para el detalle
                System.Web.UI.HtmlControls.HtmlGenericControl tabla = new System.Web.UI.HtmlControls.HtmlGenericControl("TABLE");

                //para el subacordeon
                System.Web.UI.HtmlControls.HtmlGenericControl subAcordeon = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");



                //heading
                divPanelHeading.Attributes.Add("class", "panel-heading");

                h4.Attributes.Add("class", "panel-title");

                a.Attributes.Add("data-toggle", "collapse");
                a.Attributes.Add("data-parent", "#accordion");
                a.Attributes.Add("href", "#collapse" + i.ToString());
                a.InnerText = padre.Clave + " : " + padre.Nombre;

                h4.Controls.Add(a);
                divPanelHeading.Controls.Add(h4);






                //Collapse
                divPanelCollapse.Attributes.Add("id", "collapse" + i.ToString());
                divPanelCollapse.Attributes.Add("class", "panel-collapse collapse");


                divPanelBody.Attributes.Add("class", "panel-body");


                addConcepto.Attributes.Add("href", ResolveClientUrl("~/Formas/Catalogos/catConceptosDeObraAdd.aspx?grupo=" + padre.Id) );
                addConcepto.InnerText = "Agregar Conceptos de obra";

                

                listaHijos = padre.detalleSubelementos.ToList();

                if (listaHijos.Count == 0){

                    divPanelBody.Controls.Add(addConcepto);
                    cargardetalle(padre.Id, tabla);
                    divPanelBody.Controls.Add(tabla);
                }
                    
                else
                {
                    
                    cargarSubacordeon(padre.Id, subAcordeon);
                    divPanelBody.Controls.Add(subAcordeon);
                }
                    

                
                






                
                divPanelCollapse.Controls.Add(divPanelBody);


                //Agregar Elemento
                divPanel.Attributes.Add("class", "panel panel-default");
                divPanel.Controls.Add(divPanelHeading);
                divPanel.Controls.Add(divPanelCollapse);

                this.accordion.Controls.Add(divPanel);



            }


        }

        private void cargarSubacordeon(int grupo, System.Web.UI.HtmlControls.HtmlGenericControl subacordeon)
        {
            subacordeon.Attributes.Add("class", "panel-group");
            subacordeon.Attributes.Add("id", "subacordeon" + grupo);

            List<GruposConceptosDeObra> listaPadres = uow.GruposConceptosDeObraBL.Get(p => p.ParentId == grupo).ToList();
            

            int i = 0;
            foreach (GruposConceptosDeObra padre in listaPadres)
            {
                i++;


                System.Web.UI.HtmlControls.HtmlGenericControl divPanel = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                System.Web.UI.HtmlControls.HtmlGenericControl divPanelHeading = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                System.Web.UI.HtmlControls.HtmlGenericControl divPanelCollapse = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                System.Web.UI.HtmlControls.HtmlGenericControl divPanelBody = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");

                System.Web.UI.HtmlControls.HtmlGenericControl h4 = new System.Web.UI.HtmlControls.HtmlGenericControl("H4");
                System.Web.UI.HtmlControls.HtmlGenericControl a = new System.Web.UI.HtmlControls.HtmlGenericControl("A");

                System.Web.UI.HtmlControls.HtmlGenericControl addConcepto = new System.Web.UI.HtmlControls.HtmlGenericControl("A");

                System.Web.UI.HtmlControls.HtmlGenericControl p = new System.Web.UI.HtmlControls.HtmlGenericControl("P");


                //para el detalle
                System.Web.UI.HtmlControls.HtmlGenericControl tabla = new System.Web.UI.HtmlControls.HtmlGenericControl("TABLE");

                //para el subacordeon
                System.Web.UI.HtmlControls.HtmlGenericControl subAcordeon = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");



                //heading
                divPanelHeading.Attributes.Add("class", "panel-heading");

                h4.Attributes.Add("class", "panel-title");

                a.Attributes.Add("data-toggle", "collapse");
                a.Attributes.Add("data-parent", "#subacordeon" + grupo);
                a.Attributes.Add("href", "#subcollapse" + grupo.ToString() + i.ToString());
                a.InnerText = padre.Clave + " : " + padre.Nombre;

                h4.Controls.Add(a);
                divPanelHeading.Controls.Add(h4);




                

                //Collapse
                divPanelCollapse.Attributes.Add("id", "subcollapse" + grupo.ToString() + i.ToString());
                divPanelCollapse.Attributes.Add("class", "panel-collapse collapse");


                divPanelBody.Attributes.Add("class", "panel-body");

                addConcepto.Attributes.Add("href", ResolveClientUrl("~/Formas/Catalogos/catConceptosDeObraAdd.aspx?grupo=" + padre.Id));
                addConcepto.InnerText = "Agregar Conceptos de obra";

                divPanelBody.Controls.Add(addConcepto);
                cargardetalle(padre.Id, tabla);








                
                divPanelBody.Controls.Add(tabla);
                divPanelCollapse.Controls.Add(divPanelBody);


                //Agregar Elemento
                divPanel.Attributes.Add("class", "panel panel-default");
                divPanel.Controls.Add(divPanelHeading);
                divPanel.Controls.Add(divPanelCollapse);

                subacordeon.Controls.Add(divPanel);



            }




        }



        private void cargardetalle(int grupo, System.Web.UI.HtmlControls.HtmlGenericControl tabla)
        {
            List<ConceptosDeObra> detalle = uow.ConceptosDeObraBL.Get(q => q.GruposConceptosDeObraId == grupo).ToList();


            if (detalle.Count == 0)
                return;


            tabla.Attributes.Add("class", "table");
            tabla.Attributes.Add("cellspacing", "0");

            System.Web.UI.HtmlControls.HtmlGenericControl trHead = new System.Web.UI.HtmlControls.HtmlGenericControl("TR");
            System.Web.UI.HtmlControls.HtmlGenericControl thOne = new System.Web.UI.HtmlControls.HtmlGenericControl("TH");
            System.Web.UI.HtmlControls.HtmlGenericControl thTwo = new System.Web.UI.HtmlControls.HtmlGenericControl("TH");
            System.Web.UI.HtmlControls.HtmlGenericControl thThree = new System.Web.UI.HtmlControls.HtmlGenericControl("TH");
            System.Web.UI.HtmlControls.HtmlGenericControl thFour = new System.Web.UI.HtmlControls.HtmlGenericControl("TH");
            System.Web.UI.HtmlControls.HtmlGenericControl thFive = new System.Web.UI.HtmlControls.HtmlGenericControl("TH");

            trHead.Attributes.Add("align", "center");


            thOne.InnerText = "Clave";
            thTwo.InnerText = "Nombre";
            thThree.InnerText = "Unidad de Medida";
            thFour.InnerText = "Mínimo";
            thFive.InnerText = "Máximo";

            trHead.Controls.Add(thOne);
            trHead.Controls.Add(thTwo);
            trHead.Controls.Add(thThree);
            trHead.Controls.Add(thFour);
            trHead.Controls.Add(thFive);

            tabla.Controls.Add(trHead);


            foreach (ConceptosDeObra item in detalle)
            {

                System.Web.UI.HtmlControls.HtmlGenericControl tr = new System.Web.UI.HtmlControls.HtmlGenericControl("TR");
                System.Web.UI.HtmlControls.HtmlGenericControl tdOne = new System.Web.UI.HtmlControls.HtmlGenericControl("TD");
                System.Web.UI.HtmlControls.HtmlGenericControl tdTwo = new System.Web.UI.HtmlControls.HtmlGenericControl("TD");
                System.Web.UI.HtmlControls.HtmlGenericControl tdThree = new System.Web.UI.HtmlControls.HtmlGenericControl("TD");
                System.Web.UI.HtmlControls.HtmlGenericControl tdFour = new System.Web.UI.HtmlControls.HtmlGenericControl("TD");
                System.Web.UI.HtmlControls.HtmlGenericControl tdFive = new System.Web.UI.HtmlControls.HtmlGenericControl("TD");

                tdOne.Attributes.Add("align", "left");
                tdOne.InnerText = item.Clave;
                tdTwo.InnerText = item.Nombre;


                tdThree.InnerText = item.UnidadDeMedida.Clave;
                tdFour.InnerText = item.Minimo.ToString("C2");
                tdFive.InnerText = item.Maximo.ToString("C2");

                tdFour.Attributes.Add("align", "right");
                tdFour.Attributes.Add("align", "right");

                tr.Controls.Add(tdOne);
                tr.Controls.Add(tdTwo);
                tr.Controls.Add(tdThree);
                tr.Controls.Add(tdFour);
                tr.Controls.Add(tdFive);

                tabla.Controls.Add(tr);
            }
        }

    }
}