﻿#pragma checksum "..\..\..\Views\CRUDUsuarios.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C8964D4EE50440AFCE242DE104F64108CF7F60C4E048E846DCE2AC6D029C4D27"
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
    /// CRUDUsuarios
    /// </summary>
    public partial class CRUDUsuarios : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 114 "..\..\..\Views\CRUDUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Titulo;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\Views\CRUDUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRegresar;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\Views\CRUDUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNombre;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\Views\CRUDUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbApellido;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\Views\CRUDUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDNI;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\Views\CRUDUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbCUIT;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\..\Views\CRUDUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbCorreo;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\..\Views\CRUDUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbTelefono;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\..\Views\CRUDUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbFecha;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\Views\CRUDUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPrivilegio;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\..\Views\CRUDUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imagen;
        
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
            System.Uri resourceLocater = new System.Uri("/PuntoDeVenta;component/views/crudusuarios.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\CRUDUsuarios.xaml"
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
            this.Titulo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.BtnRegresar = ((System.Windows.Controls.Button)(target));
            
            #line 132 "..\..\..\Views\CRUDUsuarios.xaml"
            this.BtnRegresar.Click += new System.Windows.RoutedEventHandler(this.BtnRegresar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbNombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbApellido = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbDNI = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbCUIT = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tbCorreo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.tbTelefono = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.tbFecha = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.cbPrivilegio = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.imagen = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

