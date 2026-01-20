<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmJornalero.aspx.cs" Inherits="frmJornalero" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:70%;" align="center">
            <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="25pt" 
                        ForeColor="#0000CC" Text="ABM Jornaleros"></asp:Label>
                </td>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Cedula"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCedula" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnAgregar" runat="server" Font-Bold="True" Text="Agregar" 
                        Width="200px" onclick="btnAgregar_Click" />
                </td>
                <td>
                    <asp:Button ID="btnAgregarSP" runat="server" Font-Bold="True" 
                        Text="Agregar - SP" Width="200px" onclick="btnAgregarSP_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnModificar" runat="server" Font-Bold="True" Text="Modificar" 
                        Width="200px" onclick="btnModificar_Click" />
                </td>
                <td>
                    <asp:Button ID="btnModificarSP" runat="server" Font-Bold="True" 
                        Text="Modificar - SP" Width="200px" onclick="btnModificarSP_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Apellido"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtApellido" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnEliminar" runat="server" Font-Bold="True" Text="Eliminar" 
                        Width="200px" onclick="btnEliminar_Click" />
                </td>
                <td>
                    <asp:Button ID="tnEliminarSP" runat="server" Font-Bold="True" 
                        Text="Eliminar - SP" Width="200px" onclick="tnEliminarSP_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Nacimiento"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNacimiento" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" Font-Bold="True" Text="Buscar" 
                        Width="200px" onclick="btnBuscar_Click" />
                </td>
                <td>
                    <asp:Button ID="BuscarSP" runat="server" Font-Bold="True" Text="Buscar - SP" 
                        Width="200px" onclick="BuscarSP_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Listado de empleados"></asp:Label>
                </td>
                <td>
                    <asp:ListBox ID="lstListaEmpleados" runat="server" Width="200px"></asp:ListBox>
                </td>
                <td>
                    <asp:Button ID="btnListarEmp" runat="server" Font-Bold="True" 
                        onclick="btnListarEmp_Click" Text="Listar Empleados" Width="200px" />
                </td>
                <td>
                    <asp:Button ID="btnListarEmpSP" runat="server" Font-Bold="True" 
                        Text="Listar Empleados - SP" Width="200px" 
                        onclick="btnListarEmpSP_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
