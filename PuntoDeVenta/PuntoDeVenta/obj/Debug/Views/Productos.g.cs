﻿#pragma checksum "..\..\..\Views\Productos.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F637BC07A6599F16A08A842C122E02CCF89B25CCBA5ECC879B10CD8849CFE3BD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using PuntoDeVenta.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PuntoDeVenta.Views {
    
    
    /// <summary>
    /// Productos
    /// </summary>
    public partial class Productos : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 15 "..\..\..\Views\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridProductos;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Views\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Contenido;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Views\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbBuscar;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Views\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCrearProducto;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Views\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid GridDatos;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\Views\Productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame FrameProductos;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PuntoDeVenta;component/views/productos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Productos.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GridProductos = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Contenido = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.tbBuscar = ((System.Windows.Controls.TextBox)(target));
            
            #line 65 "..\..\..\Views\Productos.xaml"
            this.tbBuscar.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Buscando);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnCrearProducto = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\Views\Productos.xaml"
            this.BtnCrearProducto.Click += new System.Windows.RoutedEventHandler(this.BtnCrearProducto_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.GridDatos = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.FrameProductos = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 6:
            
            #line 113 "..\..\..\Views\Productos.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnConsultar_Click);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 123 "..\..\..\Views\Productos.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnModificar_Click);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 133 "..\..\..\Views\Productos.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnEliminar_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

