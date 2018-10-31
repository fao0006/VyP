﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace www
{
    public partial class Seleccionar : System.Web.UI.Page
    {
        List<ListItem> itemsEncuestas = new List<ListItem>();

        BaseDatos db;

        
        protected void Page_Load(object sender, EventArgs e)
        {

            Encuesta encuestaActiva = null;

            db = (BaseDatos)Session["db"];
            if (db == null)
            {
                db = new BaseDatos();
                Session["db"] = db;
            }

            foreach (Encuesta en in db.EncuestasActivas())
            {
                itemsEncuestas.Add(new ListItem(en.Nombre, ((int)en.Id).ToString()));
            }

            enc.DataSource = itemsEncuestas;
            enc.DataBind();
        }
    }
}