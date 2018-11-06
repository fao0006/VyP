﻿using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www
{
    public partial class Votar : System.Web.UI.Page
    {
        BaseDatos db;
        Encuesta en;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = (BaseDatos)Session["db"];
            en = (Encuesta)Session["encuestaActiva"];
            Encuesta.Text = en.Nombre;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (db.EstaEncuesta(en.Nombre))
            {
                Valor.Text = "1";
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (db.EstaEncuesta(en.Nombre))
            {
                Valor.Text = "2";
            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            if (db.EstaEncuesta(en.Nombre))
            {
                Valor.Text = "3";
            }
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            if (db.EstaEncuesta(en.Nombre))
            {
                Valor.Text = "4";
            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            if (db.EstaEncuesta(en.Nombre))
            {
                Valor.Text = "5";
            }
        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            Server.Transfer(".\\Seleccionar.aspx");
        }

        protected void Vot_Click(object sender, EventArgs e)
        {

            if(int.TryParse(Valor.Text, out int val))
            {
                en.Puntuar(val);
                Server.Transfer(".\\Seleccionar.aspx");
            }
            else
            {
                error.Text = "Seleccione su votación.";
            }
        }
    }
}