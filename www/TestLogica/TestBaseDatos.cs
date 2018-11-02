﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;

namespace TestLogica {
    /// <summary>
    /// Descripción resumida de TestBaseDatos
    /// </summary>
    [TestClass]
    public class TestBaseDatos {
        public TestBaseDatos()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestConstructor()
        {
            BaseDatos b = new BaseDatos();
            Assert.AreEqual(b.NumUsuarios(),2);
            Assert.IsTrue(b.EstaUsuario(0));
            Assert.IsTrue(b.EstaUsuario(1));
            Assert.AreEqual(b.NumEncuestas(), 2);
            Assert.IsTrue(b.EstaEncuesta(0));
            Assert.IsTrue(b.EstaEncuesta(1));
        }

        [TestMethod]
        public void TestGuardarUsuario()
        {
            BaseDatos b = new BaseDatos();
            b.GuardarUsuario(new Usuario(2, "cuenta", "cuenta@ubu.es", "pepinillo"));
            Assert.AreEqual(b.NumUsuarios(), 3);
            Assert.IsTrue(b.EstaUsuario(2));
        }

        [TestMethod]
        public void TestGuardarEncuesta()
        {
            BaseDatos b = new BaseDatos();
            b.GuardarEncuesta(new Encuesta(2, "encuestaprueba", "esta es una encuesta de prueba", true));
            Assert.AreEqual(b.NumEncuestas(), 3);
            Assert.IsTrue(b.EstaEncuesta(2));
        }

        [TestMethod]
        public void TestEncuestasActivas()
        {
            BaseDatos b = new BaseDatos();
            b.GuardarEncuesta(new Encuesta(2, "encuestainactiva", "esta es una encuesta no activa", false));
            Assert.AreEqual(b.NumEncuestas(), 3);
            Assert.IsTrue(b.EstaEncuesta(2));
            Assert.AreEqual(b.NumEncuestasActivas(), 2);
        }
    }
}