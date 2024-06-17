using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica_Proyecto
{
    public class Querys : Encriptacion
    {
        BaseDeDatos bd = new BaseDeDatos();
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

        #region Propiedades
        private string _codigoValor;

        public string codigoValor
        {
            get { return _codigoValor; }
            set { _codigoValor = value; }
        }
        


        private string _usuario;

        public string usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private string _contraseña;

        public string contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

        private string _nombre;

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _especialidad;

        public string especialidad
        {
            get { return _especialidad; }
            set { _especialidad = value; }
        }

        private string _direccion;

        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private string _direccion2;

        public string direccion2
        {
            get { return _direccion2; }
            set { _direccion2 = value; }
        }

        private string _telefono;

        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _estado;

        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private string _estado2;

        public string estado2
        {
            get { return _estado2; }
            set { _estado2 = value; }
        }

        private decimal _precio;

        public decimal precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        private decimal _precio2;

        public decimal precio2
        {
            get { return _precio2; }
            set { _precio2 = value; }
        }

        private string _tipo;

        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private string _medida;

        public string medida
        {
            get { return _medida; }
            set { _medida = value; }
        }

        private byte[] _foto;

        public byte[] foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        private string _ingredientes;

        public string ingredientes
        {
            get { return _ingredientes; }
            set { _ingredientes = value; }
        }

        private string _descripcion;

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _restaurante;

        public string restaurante
        {
            get { return _restaurante; }
            set { _restaurante = value; }
        }

        private string _marca;

        public string marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        private string _nacionalidad;

        public string nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }

        private string _cantidad;

        public string cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private string _year;

        public string year
        {
            get { return _year; }
            set { _year = value; }
        }

        private string _cantidadSillas;

        public string cantidadSillas
        {
            get { return _cantidadSillas; }
            set { _cantidadSillas = value; }
        }

        private string _numero;

        public string numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private string _apellido1;

        public string apellido1
        {
            get { return _apellido1; }
            set { _apellido1 = value; }
        }

        private string _apellido2;

        public string apellido2
        {
            get { return _apellido2; }
            set { _apellido2 = value; }
        }

        private string _cedula;

        public string cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }

        private string _telefono2;

        public string telefono2
        {
            get { return _telefono2; }
            set { _telefono2 = value; }
        }

        private string _puesto;

        public string puesto
        {
            get { return _puesto; }
            set { _puesto = value; }
        }

        private string _rol;

        public string rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        private string _detalle;

        public string detalle
        {
            get { return _detalle; }
            set { _detalle = value; }
        }

        private string _nombreEmpresa;

        public string nombreEmpresa
        {
            get { return _nombreEmpresa; }
            set { _nombreEmpresa = value; }
        }

        private string _nombreContacto;

        public string nombreContacto
        {
            get { return _nombreContacto; }
            set { _nombreContacto = value; }
        }

        private byte[] _foto2;

        public byte[] foto2
        {
            get { return _foto2; }
            set { _foto2 = value; }
        }

        private string _clase;

        public string clase
        {
            get { return _clase; }
            set { _clase = value; }
        }

        private string _linea;

        public string linea
        {
            get { return _linea; }
            set { _linea = value; }
        }

        private string _cantidadMedida;

        public string cantidadMedida
        {
            get { return _cantidadMedida; }
            set { _cantidadMedida = value; }
        }

        private string _prefijo;

        public string prefijo
        {
            get { return _prefijo; }
            set { _prefijo = value; }
        }

        private string _fecha;

        public string fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private string _correo;

        public string correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        private string _monto;

        public string monto
        {
            get { return _monto; }
            set { _monto = value; }
        }
        

        private string _celular;

        public string celular
        {
            get { return _celular; }
            set { _celular = value; }
        }

        private string _fax;

        public string fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        private string _telOficina;

        public string telOficina
        {
            get { return _telOficina; }
            set { _telOficina = value; }
        }

        private string _adminSist;

        public string adminSist
        {
            get { return _adminSist; }
            set { _adminSist = value; }
        }

        private string _adminSegu;

        public string adminSegu
        {
            get { return _adminSegu; }
            set { _adminSegu = value; }
        }

        private string _adminCuent;

        public string adminCuent
        {
            get { return _adminCuent; }
            set { _adminCuent = value; }
        }

        private string _adminRestau;

        public string adminRestau
        {
            get { return _adminRestau; }
            set { _adminRestau = value; }
        }

        private string _unidad;

        public string unidad
        {
            get { return _unidad; }
            set { _unidad = value; }
        }

        private string _escala;

        public string escala
        {
            get { return _escala; }
            set { _escala = value; }
        }

        private string _simbologia;

        public string simbologia
        {
            get { return _simbologia; }
            set { _simbologia = value; }
        }

        private string _reservacion;

        public string reservacion
        {
            get { return _reservacion; }
            set { _reservacion = value; }
        }

        private string _silla1;

        public string silla1
        {
            get { return _silla1; }
            set { _silla1 = value; }
        }

        private string _silla2;

        public string silla2
        {
            get { return _silla2; }
            set { _silla2 = value; }
        }

        private string _silla3;

        public string silla3
        {
            get { return _silla3; }
            set { _silla3 = value; }
        }

        private string _silla4;

        public string silla4
        {
            get { return _silla4; }
            set { _silla4 = value; }
        }


        private string _numMesa;

        public string numMesa
        {
            get { return _numMesa; }
            set { _numMesa = value; }
        }

        private string _tiempo;

        public string tiempo
        {
            get { return _tiempo; }
            set { _tiempo = value; }
        }

        private string _entrada;

        public string entrada
        {
            get { return _entrada; }
            set { _entrada = value; }
        }

        private string _salida;

        public string salida
        {
            get { return _salida; }
            set { _salida = value; }
        }

        private string _numSilla;

        public string numSilla
        {
            get { return _numSilla; }
            set { _numSilla = value; }
        }

        private string _barraCliente;

        public string barraCliente
        {
            get { return _barraCliente; }
            set { _barraCliente = value; }
        }

        private string _fechaReservacion;

        public string fechaReservacion
        {
            get { return _fechaReservacion; }
            set { _fechaReservacion = value; }
        }

        private string _montoApertura;

        public string montoApertura
        {
            get { return _montoApertura; }
            set { _montoApertura = value; }
        }

        private string _montoCierre;

        public string montoCierre
        {
            get { return _montoCierre; }
            set { _montoCierre = value; }
        }
        
        #endregion

        #region Metodos
        public string[] autenticar()
        {
            string[] privilegios = new string[7];
            string rol = string.Empty;
            BaseDeDatos bd = new BaseDeDatos();
            //encripta user
            string UsuarioEncrip = encriptacion(_usuario);
            //encripta pass
            string ContraEncrip = encriptacion(_contraseña);

            string result = bd.selectstring(string.Format("select LoginUsuario from Usuarios where LoginUsuario = '{0}' and ContrasenaUsuario = '{1}'", UsuarioEncrip, ContraEncrip)).ToString();
            if (!string.IsNullOrEmpty(result)) 
            {
                /*string tipo = bd.selectstring("select UPPER (Rol) from Usuarios where LoginUsuario = '" + UsuarioEncrip + "' and ContrasenaUsuario = '" + ContraEncrip + "'").ToString();
                string tipo = DecryptString(tipoEncrip);
                if (tipo.Equals("ADMIN"))
                {
                    rol = "ADMIN";
                    return rol;
                }
                if (tipo.Equals("EMPLEADO"))
                {
                    rol = "EMPLEADO";
                    return rol;
                 */
                //dssdfg
                string adminSeguridad = bd.selectstring("Select AdminSeguridadUsuario  from Usuarios where AdminSeguridadUsuario= '" + encriptacion("SI") + "' and LoginUsuario = '" + UsuarioEncrip + "' and ContrasenaUsuario = '" + ContraEncrip + "'").ToString();
                string adminSistema = bd.selectstring("Select AdminSistemaUsuario  from Usuarios where AdminSistemaUsuario= '" + encriptacion("SI") + "' and LoginUsuario = '" + UsuarioEncrip + "' and ContrasenaUsuario = '" + ContraEncrip + "'").ToString();      
                string adminRestaurante = bd.selectstring("Select AdminRestauranteUsuario  from Usuarios where AdminRestauranteUsuario= '" + encriptacion("SI") + "' and LoginUsuario = '" + UsuarioEncrip + "' and ContrasenaUsuario = '" + ContraEncrip + "'").ToString();
                string adminCuentas = bd.selectstring("Select AdminCuentasUsuario from Usuarios where AdminCuentasUsuario= '" + encriptacion("SI") + "' and LoginUsuario = '" + UsuarioEncrip + "' and ContrasenaUsuario = '" + ContraEncrip + "'").ToString(); ;
       
                if (!string.IsNullOrEmpty(adminSeguridad))
                {
                    privilegios[0] = "Administrador Seguridad";
                }
                if(!string.IsNullOrEmpty(adminSistema))
                {
                    privilegios[1] = "Administrador Sistema";
                }
                if(!string.IsNullOrEmpty(adminRestaurante))
                {
                    privilegios[2] = "Administrador Restaurante";
                    string restaurante = bd.selectstring("Select AdminTipoRestauranteUsuario from Usuarios where AdminRestauranteUsuario= '" + encriptacion("SI") + "' and LoginUsuario = '" + UsuarioEncrip + "' and ContrasenaUsuario = '" + ContraEncrip + "'").ToString();
                    privilegios[3] = desencriptacion(restaurante);
                }
                if (!string.IsNullOrEmpty(adminCuentas))
                {
                    privilegios[4] = "Administrador Cuentas";
                }
                privilegios[5] = "TRUE";
                privilegios[6] = _usuario;
                //adsfdf
               
            }
            return privilegios;
        }

        public Boolean agregar_Restaurante()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string especialidad = encriptacion(_especialidad);
            string direccion = encriptacion(_direccion);
            string telefono = encriptacion(_telefono);
            string estado = encriptacion(_estado);
            
            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Restaurante(CodigoRestaurante,NombreRestaurante,DireccionRestaurante,TelefonoRestaurante,EspecialidadRestaurante,EstadoRestaurante) values ('" + codigo + "','" + nombre + "','" + direccion + "','" + telefono + "','" + especialidad + "','" + estado + "')";
            if (bd.executecommand(sql))
            {
                actualizarConsecutivos("Restaurante", "PrefijoRestaurante", "Restaurantes");

                return true;
            }
            else
            {
                return false;
            }
        }

      
        public Boolean agregar_Buffed()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string precio = encriptacion(_precio.ToString());
            string tipo = encriptacion(_tipo);
            string medida = encriptacion(_medida);
            //string foto = encriptacion(_foto);


  

            BaseDeDatos bd = new BaseDeDatos();

            string sql = "insert into Buffet(CodigoBuffet,NombreBuffet,PrecioBuffet,TipoComidaBuffet,UnidadMedidaBuffet,FotoBuffet) values ('" + codigo + "','" + nombre + "','" + precio + "','" + tipo + "','" + medida + "',@Imagen)";
            if (bd.executecommandImagen(_foto, sql))
            {
                actualizarConsecutivos("Buffet", "PrefijoBuffet", "Buffet");

                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_BebidaCaliente()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string ingrediente = encriptacion(_ingredientes);
            string precio = encriptacion(_precio.ToString());
            string restaurante = encriptacion(_restaurante);
            string descripcion = encriptacion(_descripcion);
            //string foto = encriptacion(_foto);

            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into BebidaCalientes(CodigoBebida,NombreBebida,IngredientesBebida,PrecioBebida,RestauranteBebida,DescripcionBebida,Foto) values ('" + codigo + "','" + nombre + "','" + ingrediente + "','" + precio + "','" + restaurante + "','" + descripcion + "',@Imagen)";
            if (bd.executecommandImagen(_foto, sql))
            {
                
                actualizarConsecutivos("BebidaCalientes", "PrefijoBebidaCaliente", "Bebidas Calientes");

                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_BebidaHelada()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string ingrediente = encriptacion(_ingredientes);
            string precio = encriptacion(_precio.ToString());
            string restaurante = encriptacion(_restaurante);
            string descripcion = encriptacion(_descripcion);
            //string foto = encriptacion(_foto);

            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into BebidaHeladas(CodigoBebida,NombreBebida,IngredientesBebida,PrecioBebida,RestauranteBebida,DescripcionBebida,Foto) values ('" + codigo + "','" + nombre + "','" + ingrediente + "','" + precio + "','" + restaurante + "','" + descripcion + "',@Imagen)";
            if (bd.executecommandImagen(_foto, sql))
            {
              
                actualizarConsecutivos("BebidaHeladas", "PrefijoBebidaHelada", "Bebidas Heladas");
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_BebidaGaseosa()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string marca = encriptacion(_marca);
            string precio = encriptacion(_precio.ToString());
            string restaurante = encriptacion(_restaurante);
            string descripcion = encriptacion(_descripcion);
            string cantidad = encriptacion(_cantidad);
            string nacionalidad = encriptacion(_nacionalidad);
            //string foto = encriptacion(_foto);

            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into BebidaGaseosas(CodigoBebida,NombreBebida,PrecioBebida,RestauranteBebida,MarcaBebida,NacionalidadBebida,CantidadBebida,DescripcionBebida,Foto) values ('" + codigo + "','" + nombre + "','" + precio + "','" + restaurante + "','" + marca + "','" + nacionalidad + "','" + cantidad + "','" + descripcion + "',@Imagen)";
            if (bd.executecommand(sql))
            {

                actualizarConsecutivos("BebidaGaseosas", "PrefijoBebidaGaseosa", "Bebidas Gaseosas");
        
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Vinos()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string marca = encriptacion(_marca);
            string precio = encriptacion(_precio.ToString());
            string precio2 = encriptacion(_precio2.ToString());
            string restaurante = encriptacion(_restaurante);
            string descripcion = encriptacion(_descripcion);
            string cantidad = encriptacion(_cantidad);
            string nacionalidad = encriptacion(_nacionalidad);
            string year = encriptacion(_year);
            //string foto = encriptacion(_foto);

            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Vinos(CodigoVino,NombreVino,RestauranteVino,DescripcionVino,CantidadVino,MarcaVino,PrecioUnitarioVino,PrecioBotellaVino,NacionalidadVino,AñoCosechaVino,FotoVino) values ('" + codigo + "','" + nombre + "','" + restaurante + "','" + descripcion + "','" + cantidad + "','" + marca + "','" + precio + "','" + precio2 + "','" + nacionalidad + "','" + year + "',@Imagen)";
            if (bd.executecommandImagen(_foto, sql))
            {

                actualizarConsecutivos("Vinos", "PrefijoVino", "Vinos");
               
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Licor()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string marca = encriptacion(_marca);
            string precio = encriptacion(_precio.ToString());
            string precio2 = encriptacion(_precio2.ToString());
            string restaurante = encriptacion(_restaurante);
            string descripcion = encriptacion(_descripcion);
            string cantidad = encriptacion(_cantidad);
            string nacionalidad = encriptacion(_nacionalidad);
            //string foto = encriptacion(_foto);

            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Licores(CodigoLicor,NombreLicor,RestauranteLicor,DescripcionLicor,CantidadLicor,MarcaLicor,PrecioUnitarioLicor,PrecioBotellaLicor,NacionalidadLicor,FotoLicor) values ('" + codigo + "','" + nombre + "','" + restaurante + "','" + descripcion + "','" + cantidad + "','" + marca + "','" + precio + "','" + precio2 + "','" + nacionalidad + "',@Imagen)";
            if (bd.executecommandImagen(_foto, sql))
            {
                actualizarConsecutivos("Licores", "PrefijoLicor", "Licores");
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Especiales()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string ingrediente = encriptacion(_ingredientes);
            string precio = encriptacion(_precio.ToString());
            string descripcion = encriptacion(_descripcion);

            //string foto = encriptacion(_foto);

            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Especiales(CodigoEspecial,NombrePlatilloEspecial,IngredientesEspecial,PrecioEspecial,DetalleEspecial,FotoEspecial) values ('" + codigo + "','" + nombre + "','" + ingrediente + "','" + precio + "','" + descripcion + "',@Imagen)";
            if (bd.executecommandImagen(_foto, sql))
            {
                actualizarConsecutivos("Especiales", "PrefijoEspecial", "Especiales");
                
                return true;
            }
            else
            {
                return false;
            }
        }


        public Boolean agregar_Mesas()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string numero = encriptacion(_numero);
            string sillas = encriptacion(_cantidadSillas);
            string restaurante = encriptacion(_restaurante);


            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Mesas(CodigoMesa,NombreMesa,NumeroMesa,CantidadSillasMesa,RestauranteMesa) values ('" + codigo + "','" + nombre + "','" + numero + "','" + sillas + "','" + restaurante + "')";
            if (bd.executecommand(sql))
            {
                actualizarConsecutivos("Mesas", "PrefijoMesa", "Mesas");
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Empleado()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string cedula = encriptacion(_cedula);
            string apellido1 = encriptacion(_apellido1);
            string apellido2 = encriptacion(_apellido2);
            string telefono1 = encriptacion(_telefono);
            string telefono2 = encriptacion(_telefono2);
            string puesto = encriptacion(_puesto);
            string nacionalidad = encriptacion(_nacionalidad);
            string restaurante = encriptacion(_restaurante);

            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Empleados(CodigoEmpleado,CedulaEmpleado,NombreEmpleado,PrimerApellidoEmpleado,SegundoApellidoEmpleado,Telefono1Empleado,Telefono2Empleado,PuestoEmpleado,NacionalidadEmpleado,RestauranteEmpleado,FotoEmpleado) values ('" + codigo + "','" + cedula + "','" + nombre + "','" + apellido1 + "','" + apellido2 + "','" + telefono1 + "','" + telefono2 + "','" + puesto + "','" + nacionalidad + "','" + restaurante + "',@Imagen)";
            if (bd.executecommandImagen(_foto, sql))
            {
                actualizarConsecutivos("Empleados", "PrefijoEmpleado", "Empleados");
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Puesto()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string rol = encriptacion(_rol);
            string interno = encriptacion(_estado);
            string externo = encriptacion(_estado2);


            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Puestos(CodigoPuesto,NombrePuesto,RolPuesto,InternoPuesto,ExternoPuesto) values ('" + codigo + "','" + nombre + "','" + rol + "','" + interno + "','" + externo + "')";
            if (bd.executecommand(sql))
            {
                actualizarConsecutivos("Puestos", "PrefijoPuesto", "Puestos");
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Marcas() // 2 fotos
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string nacionalidad = encriptacion(_nacionalidad);
            string descripcion = encriptacion(_descripcion);

            string cedula = encriptacion(_cedula);
            string nombreEmpresa = encriptacion(_nombreEmpresa);
            string detalle = encriptacion(_detalle);
            string telefono = encriptacion(_telefono);


            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Marcas(CodigoMarca,NombreMarca,NacionalidadMarca,DescripcionMarca,FotoMarca,CedulaContacto,NombreEmpresaContacto,DetalleEmpresaContacto,TelefonoEmpresaContacto,FotoEmpresaContacto) values ('" + codigo + "','" + nombre + "','" + nacionalidad + "','" + descripcion + "',@Imagen1,'" + cedula + "','" + nombreEmpresa + "','" + detalle + "','" + telefono + "',@Imagen2)";
            if (bd.executecommand2Imagen(_foto,_foto2, sql))
            {
                actualizarConsecutivos("Marcas", "PrefijoMarca", "Marcas");
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Comestibles()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string cantidad = encriptacion(_cantidad);
            string tipo = encriptacion(_tipo);
            string restaurante = encriptacion(_restaurante);
            string marca = encriptacion(_marca);
            string clase = encriptacion(_clase);
            string linea = encriptacion(_linea);
            string medida = encriptacion(_medida);


            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Comestibles(CodigoComestible,NombreComestible,CantidadComestible,TipoComestible,RestauranteComestible,MarcaComestible,ClaseComestible,LineaComestible,UnidadMedidaComestible) values ('" + codigo + "','" + nombre + "','" + cantidad + "','" + tipo + "','" + restaurante + "','" + marca + "','" + clase + "','" + linea + "','" + medida + "')";
            if (bd.executecommand(sql))
            {
                actualizarConsecutivos("Comestibles", "PrefijoComestible", "Comestibles");
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Desechable()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string restaurante = encriptacion(_restaurante);
            string marca = encriptacion(_marca);
            string cantidad = encriptacion(_cantidad);
            string descripcion = encriptacion(_descripcion);


            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Desechables(CodigoDesechable,NombreDesechable,RestauranteDesechable,MarcaDesechable,CantidadDesechable,DescripcionDesechable) values ('" + codigo + "','" + nombre + "','" + restaurante + "','" + marca + "','" + cantidad + "','" + descripcion + "')";
            if (bd.executecommand(sql))
            {
                actualizarConsecutivos("Desechables", "PrefijoDesechable", "Desechables y Empaques");
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Limpieza()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string restaurante = encriptacion(_restaurante);
            string marca = encriptacion(_marca);
            string cantidad = encriptacion(_cantidad);
            string descripcion = encriptacion(_descripcion);
            string tipo = encriptacion(_tipo);
            string cantidadmedida = encriptacion(_cantidadMedida);
            string medida = encriptacion(_medida);
            string estado = encriptacion(_estado);


            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Limpieza(CodigoLimpieza,NombreLimpieza,RestauranteLimpieza,MarcaLimpieza,CantidadLimpieza,DescripcionLimpieza,TipoLimpieza,CantidadMedidaLimpieza,UnidadMedidaLimpieza,LiquidoLimpieza) values ('" + codigo + "','" + nombre + "','" + restaurante + "','" + marca + "','" + cantidad + "','" + descripcion + "','" + tipo + "','" + cantidadmedida + "','" + medida + "','" + estado + "')";
            if (bd.executecommand(sql))
            {
                actualizarConsecutivos("Limpieza", "PrefijoLimpieza", "Limpieza e Higiene");
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Tecnologia()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string restaurante = encriptacion(_restaurante);
            string marca = encriptacion(_marca);
            string cantidad = encriptacion(_cantidad);
            string descripcion = encriptacion(_descripcion);


            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Tecnologias(CodigoTecnologia,NombreTecnologia,RestauranteTecnologia,MarcaTecnologia,CantidadTecnologia,DescripcionTecnologia) values ('" + codigo + "','" + nombre + "','" + restaurante + "','" + marca + "','" + cantidad + "','" + descripcion + "')";
            if (bd.executecommand(sql))
            {
                actualizarConsecutivos("Tecnologias", "PrefijoTecnologia", "Tecnología");
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Utencilio()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string restaurante = encriptacion(_restaurante);
            string marca = encriptacion(_marca);
            string cantidad = encriptacion(_cantidad);
            string descripcion = encriptacion(_descripcion);


            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Utencilios(CodigoUtencilios,NombreUtencilios,RestauranteUtencilios,MarcaUtencilios,CantidadUtencilios,DescripcionUtencilios) values ('" + codigo + "','" + nombre + "','" + restaurante + "','" + marca + "','" + cantidad + "','" + descripcion + "')";
            if (bd.executecommand(sql))
            {
                actualizarConsecutivos("Utencilios", "PrefijoUtencilios", "Equipos y Utensilios");
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Consecutivo()
        {
            string[] valores = CodigoTabla("CodigoConsecutivo", "Consecutivos");
            string codigo = encriptacion(valores[0]);

            string tipo = encriptacion(_tipo);
            string descripcion = encriptacion(_descripcion);
            string valor = encriptacion(_numero);
            string estado = encriptacion(_estado);
            string prefijo = string.Empty;
            if (!string.IsNullOrEmpty(_prefijo))
            {
                 prefijo = encriptacion(_prefijo);
            }


            BaseDeDatos bd = new BaseDeDatos();
            string tipoExiste = bd.selectstring("select TipoConsecutivo from Consecutivos where TipoConsecutivo = '"+tipo+"'").ToString();
            if (string.IsNullOrEmpty(tipoExiste))
            {
                string sql = "insert into Consecutivos(CodigoConsecutivo,TipoConsecutivo,DescripcionConsecutivo,ValorConsecutivo,ContienePrefijoConsecutivo,PrefijoConsecutivo) values ('" + codigo + "','" + tipo + "','" + descripcion + "','" + valor + "','" + estado + "','" + prefijo + "')";
                if (bd.executecommand(sql))
                {
                    actualizarTablaConsecutivos();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Boolean ProductosProveedor(string producto,string codigo)
        {

            BaseDeDatos bd = new BaseDeDatos();

            string CodProductoRestaurant = bd.selectstring("select CodigoTecnologia from Tecnologias where NombreTecnologia = '" + encriptacion(producto) + "'").ToString();
            string PrefijoProductoRestaurant = bd.selectstring("select PrefijoTecnologia from Tecnologias where NombreTecnologia = '" + encriptacion(producto) + "'").ToString();

            if (string.IsNullOrEmpty(CodProductoRestaurant) && string.IsNullOrEmpty(CodProductoRestaurant))
            {
                CodProductoRestaurant = bd.selectstring("select CodigoComestible from Comestibles where NombreComestible = '" + encriptacion(producto) + "'").ToString();
                PrefijoProductoRestaurant = bd.selectstring("select PrefijoComestible from Comestibles where NombreComestible = '" + encriptacion(producto) + "'").ToString();
            }
            if (string.IsNullOrEmpty(CodProductoRestaurant) && string.IsNullOrEmpty(CodProductoRestaurant))
            {
                CodProductoRestaurant = bd.selectstring("select CodigoDesechable from Desechables where NombreDesechable = '" + encriptacion(producto) + "'").ToString();
                PrefijoProductoRestaurant = bd.selectstring("select PrefijoDesechable from Desechables where NombreDesechable = '" + encriptacion(producto) + "'").ToString();
            }
            if (string.IsNullOrEmpty(CodProductoRestaurant) && string.IsNullOrEmpty(CodProductoRestaurant))
            {
                CodProductoRestaurant = bd.selectstring("select CodigoUtencilios from Utencilios where NombreUtencilios = '" + encriptacion(producto) + "'").ToString();
                PrefijoProductoRestaurant = bd.selectstring("select PrefijoUtencilios from Utencilios where NombreUtencilios = '" + encriptacion(producto) + "'").ToString();
            }
            if (string.IsNullOrEmpty(CodProductoRestaurant) && string.IsNullOrEmpty(CodProductoRestaurant))
            {
                CodProductoRestaurant = bd.selectstring("select CodigoLimpieza from Limpieza where NombreLimpieza = '" + encriptacion(producto) + "'").ToString();
                PrefijoProductoRestaurant = bd.selectstring("select PrefijoLimpieza from Limpieza where NombreLimpieza = '" + encriptacion(producto) + "'").ToString();
            }

            /*adminCod("CodigoProveedor", "Proveedores", 2);
            string result = bd.selectstring("SELECT top 1 CodigoProveedor from Proveedores order by CodigoProveedor desc");
            adminCod("CodigoProveedor", "Proveedores", 1);*/
            MessageBox.Show(codigo);
            string sql = "insert into ProductosProveedor(CodigoProducto,PrefijoProducto,CodigoProveedor) values ('" + CodProductoRestaurant + "','" + PrefijoProductoRestaurant + "','" + encriptacion(codigo) + "')";
            
            if (bd.executecommand(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public Boolean agregar_Proveedor()
        {
            string codigo = encriptacion(_codigoValor);
            string cedula = encriptacion(_cedula);
            string fecha = encriptacion(_fecha);
            string nombre = encriptacion(_nombre);
            string primerApellido = encriptacion(_apellido1);
            string segundoApellido = encriptacion(_apellido2);
            string correo = encriptacion(_correo);
            string direccion = encriptacion(_direccion);
            string telProveedor = encriptacion(_telOficina);
            string fax = encriptacion(_fax);
            string celular = encriptacion(_celular);
            //Foto
            string nombreContact = encriptacion(_nombreContacto);
            string telContact = encriptacion(_telefono);
            string direcionContact = encriptacion(_direccion2);

            


            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Proveedores(CodigoProveedor,CedulaIdentidadProveedor,FechaIngresoProveedor,NombreProveedor,PrimerApellidoProveedor,SegundoApellidoProveedor,CorreoProveedor,DireccionProveedor,TelefonoOficinaProveedor,FAXProveedor,CelularProveedor,FotoProveedor,NombreContactoProveedor,TelefonoContactoProveedor,DireccionContactoProveedor) values  ('" + codigo + "','" + cedula + "','" + fecha + "','" + nombre + "','" + primerApellido + "','" + segundoApellido + "','" + correo + "','" + direccion + "','" + telProveedor + "','" + fax + "','" + celular + "',@Imagen,'" + nombreContact + "','" + telContact + "','" + direcionContact + "')";
            if (bd.executecommandImagen(_foto, sql))
            {
                actualizarConsecutivos("Proveedores", "PrefijoProveedor", "Proveedores");
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Usuario()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string primerApellido = encriptacion(_apellido1);
            string segundoApellido = encriptacion(_apellido2);
            string telefono1 = encriptacion(_telefono);
            string telefono2 = encriptacion(_telefono2);
            string adminSistema = encriptacion(_adminSist);
            string adminSeguridad = encriptacion(_adminSegu);
            string adminRestaurante = encriptacion(_adminRestau);
            string adminTipoRestaurante = encriptacion(_restaurante);
            string adminCuentas = encriptacion(_adminCuent);
            string usuario = encriptacion(_usuario);
            string contrasena = encriptacion(_contraseña);


            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Usuarios(CodigoUsuario,NombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,Telefono1Usuario,Telefono2Usuario,AdminSistemaUsuario,AdminSeguridadUsuario,AdminRestauranteUsuario,AdminTipoRestauranteUsuario,AdminCuentasUsuario,LoginUsuario,ContrasenaUsuario) values ('" + codigo + "','" + nombre + "','" + primerApellido + "','" + segundoApellido + "','" + telefono1 + "','" + telefono2 + "','" + adminSistema + "','" + adminSeguridad + "','" + adminRestaurante + "','" + adminTipoRestaurante + "','" + adminCuentas + "','" + usuario + "','" + contrasena + "')";
            if (bd.executecommand(sql))
            {

                actualizarConsecutivos("Usuarios", "PrefijoUsuario", "Usuarios");
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean actualizar_UsuarioPassword()
        {
            string usuario = encriptacion(_usuario);
            string contrasena = encriptacion(_contraseña);


            BaseDeDatos bd = new BaseDeDatos();
            string user = bd.selectstring("select LoginUsuario from Usuarios where LoginUsuario = '"+usuario+"'");
            if (!string.IsNullOrEmpty(user))
            {
                string sql = "update Usuarios set ContrasenaUsuario='" + contrasena + "' where LoginUsuario = '" + usuario + "'";
                if (bd.executecommand(sql))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Pais()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            //string foto = encriptacion(_foto);



            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Paises(CodigoPais,NombrePais,FotoPais) values ('" + codigo + "','" + nombre + "','" + _foto + "')";
            if (bd.executecommand(sql))
            {

                actualizarConsecutivos("Paises", "PrefijoPais", "Países");

                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Rol()
        {
            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string descripcion = encriptacion(_descripcion);

            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Roles(CodigoRol,NombreRol,DescripcionRol) values ('" + codigo + "','" + nombre + "','" + descripcion + "')";
            if (bd.executecommand(sql))
            {
                actualizarConsecutivos("Roles", "PrefijoRol", "Eventos o Roles");

                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Unidad()
        {
            string codigo = encriptacion(_codigoValor);
            string unidad = encriptacion(_unidad);
            string escala = encriptacion(_escala);
            string detalle = encriptacion(_detalle);
            string simbologia = encriptacion(_simbologia);

            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into UnidadesMedida(UnidadMedida,EscalaMedida,DetalleMedida,SimbologiaMedida) values ('" + codigo + "','" + unidad + "','" + escala + "','" + detalle + "','" + simbologia + "')";
            if (bd.executecommand(sql))
            {

                actualizarConsecutivos("UnidadesMedida", "PrefijoMedida", "Unidades de Medida");

                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_clientes(ArrayList List, ArrayList List1, ArrayList List2, ArrayList List3, ArrayList List4)
        {
            string sql = string.Empty;

            string codigo = encriptacion(_codigoValor);
            string nombre = encriptacion(_nombre);
            string monto = encriptacion(_monto);
            string detalleSinEncrip = string.Join(",", List.ToArray());
            string detalle = encriptacion(detalleSinEncrip);
            string fecha = encriptacion(_fecha);
            string restaurante = encriptacion(_restaurante);


            string list1 = string.Empty;
            string list2 = string.Empty;
            string list3 = string.Empty;
            string list4 = string.Empty;
            string silla1 = string.Empty;
            string silla2 = string.Empty;
            string silla3 = string.Empty;
            string silla4 = string.Empty;
            string salida = string.Empty;
            string numMesa = string.Empty;
            string numSilla = string.Empty;
            string barraCliente = null;
            string reservacion = string.Empty;
            string FechaReservacion = string.Empty;

            //
            string fechaReserva = string.Empty;
            //

           

            if (!string.IsNullOrEmpty(_reservacion))
            {
                reservacion = encriptacion(_reservacion);
            }

            string list1SinEncrip = string.Join(",", List1.ToArray());
            if (!string.IsNullOrEmpty(list1SinEncrip))
            {
                list1 = encriptacion(list1SinEncrip);
            }


            string list2SinEncrip = string.Join(",", List2.ToArray());
            if (!string.IsNullOrEmpty(list2SinEncrip))
            {
                list2 = encriptacion(list2SinEncrip);
            }

            string list3SinEncrip = string.Join(",", List3.ToArray());
            if (!string.IsNullOrEmpty(list3SinEncrip))
            {
                list3 = encriptacion(list3SinEncrip);
            }

            string list4SinEncrip = string.Join(",", List4.ToArray());
            if (!string.IsNullOrEmpty(list4SinEncrip))
            {
                list4 = encriptacion(list4SinEncrip);
            }



            if (!string.IsNullOrEmpty(_silla1))
            {
                 silla1 = encriptacion(_silla1);
            }
            if (!string.IsNullOrEmpty(_silla2))
            {
                 silla2 = encriptacion(_silla2);
            }
            if (!string.IsNullOrEmpty(_silla3))
            {
                 silla3 = encriptacion(_silla3);
            }
            if (!string.IsNullOrEmpty(_silla4))
            {
                 silla4 = encriptacion(_silla4);
            }
          

            if (!string.IsNullOrEmpty(_numMesa))
            {
                numMesa = encriptacion(_numMesa);
            }
            if (!string.IsNullOrEmpty(_numSilla))
            {
                numSilla = encriptacion(_numSilla);
            }

            string tiempoMesa = encriptacion(_tiempo);
            string estado = encriptacion(_estado);
           
            
            
            string entrada = encriptacion(_entrada);

            
            if (!string.IsNullOrEmpty(_salida)) {
                 salida = encriptacion(_salida);
            }

            if (!string.IsNullOrEmpty(_fechaReservacion))
            {
                FechaReservacion = encriptacion(_fechaReservacion);
            }


            if (!string.IsNullOrEmpty(_barraCliente))
            {
                barraCliente = encriptacion(_barraCliente);
                sql = "insert into Clientes(CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,RestauranteCliente,silla1Cliente,silla2Cliente,silla3Cliente,silla4Cliente,List1Cliente,List2Cliente,List3Cliente,List4Cliente,TiempoMesa,NumMesa,HoraEntrada,HoraSalida,EstadoPago,NumSilla,BarraCliente,FechaReservacion) values ('" + codigo + "','" + nombre + "','" + monto + "','" + detalle + "','" + fecha + "','" + reservacion + "','" + restaurante + "','" + silla1 + "','" + silla2 + "','" + silla3 + "','" + silla4 + "','" + list1 + "','" + list2 + "','" + list3 + "','" + list4 + "','" + tiempoMesa + "','" + numMesa + "','" + entrada + "','" + salida + "','" + estado + "','" + numSilla + "','" + barraCliente + "','" + FechaReservacion + "')";
            }
            else
            {
                sql = "insert into Clientes(CodigoCliente,NombreCompletoCliente,MontoPagadoCliente,DetalleCliente,FechaCliente,ReservacionCliente,RestauranteCliente,silla1Cliente,silla2Cliente,silla3Cliente,silla4Cliente,List1Cliente,List2Cliente,List3Cliente,List4Cliente,TiempoMesa,NumMesa,HoraEntrada,HoraSalida,EstadoPago,NumSilla,FechaReservacion) values ('" + codigo + "','" + nombre + "','" + monto + "','" + detalle + "','" + fecha + "','" + reservacion + "','" + restaurante + "','" + silla1 + "','" + silla2 + "','" + silla3 + "','" + silla4 + "','" + list1 + "','" + list2 + "','" + list3 + "','" + list4 + "','" + tiempoMesa + "','" + numMesa + "','" + entrada + "','" + salida + "','" + estado + "','" + numSilla + "','" + FechaReservacion + "')";

            }
           
            BaseDeDatos bd = new BaseDeDatos();

            if (bd.executecommand(sql))
            {
                actualizarConsecutivos("Clientes", "PrefijoCliente", "Clientes");

                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean actualizar_clientes(ArrayList List, ArrayList List1, ArrayList List2, ArrayList List3, ArrayList List4,string codigo)
        {
            string id = encriptacion(codigo);


            string nombre = encriptacion(_nombre);
            string monto = encriptacion(_monto);
            string detalleSinEncrip = string.Join(",", List.ToArray());
            string detalle = encriptacion(detalleSinEncrip);
            string fecha = encriptacion(_fecha);
            string restaurante = encriptacion(_restaurante);
            string FechaReservacion = string.Empty;


            string list1 = string.Empty;
            string list2 = string.Empty;
            string list3 = string.Empty;
            string list4 = string.Empty;
            string silla1 = string.Empty;
            string silla2 = string.Empty;
            string silla3 = string.Empty;
            string silla4 = string.Empty;
            string salida = string.Empty;
            string numMesa = string.Empty;
            string numSilla = string.Empty;
            string barraCliente = string.Empty;
            string reservacion = string.Empty;

            if (!string.IsNullOrEmpty(_reservacion))
            {
                reservacion = encriptacion(_reservacion);
            }

            string list1SinEncrip = string.Join(",", List1.ToArray());
            if (!string.IsNullOrEmpty(list1SinEncrip))
            {
                list1 = encriptacion(list1SinEncrip);
            }


            string list2SinEncrip = string.Join(",", List2.ToArray());
            if (!string.IsNullOrEmpty(list2SinEncrip))
            {
                list2 = encriptacion(list2SinEncrip);
            }

            string list3SinEncrip = string.Join(",", List3.ToArray());
            if (!string.IsNullOrEmpty(list3SinEncrip))
            {
                list3 = encriptacion(list3SinEncrip);
            }

            string list4SinEncrip = string.Join(",", List4.ToArray());
            if (!string.IsNullOrEmpty(list4SinEncrip))
            {
                list4 = encriptacion(list4SinEncrip);
            }



            if (!string.IsNullOrEmpty(_silla1))
            {
                silla1 = encriptacion(_silla1);
            }
            if (!string.IsNullOrEmpty(_silla2))
            {
                silla2 = encriptacion(_silla2);
            }
            if (!string.IsNullOrEmpty(_silla3))
            {
                silla3 = encriptacion(_silla3);
            }
            if (!string.IsNullOrEmpty(_silla4))
            {
                silla4 = encriptacion(_silla4);
            }


            if (!string.IsNullOrEmpty(_numMesa))
            {
                numMesa = encriptacion(_numMesa);
            }
            if (!string.IsNullOrEmpty(_numSilla))
            {
                numSilla = encriptacion(_numSilla);
            }

            string tiempoMesa = encriptacion(_tiempo);
            string estado = encriptacion(_estado);



            string entrada = encriptacion(_entrada);

            if (!string.IsNullOrEmpty(_barraCliente))
            {
                barraCliente = encriptacion(_barraCliente);
            }
        


            if (!string.IsNullOrEmpty(_salida))
            {
                salida = encriptacion(_salida);
            }

            if (!string.IsNullOrEmpty(_fechaReservacion))
            {
                FechaReservacion = encriptacion(_fechaReservacion);
            }
           

            BaseDeDatos bd = new BaseDeDatos();

            string sql = "update Clientes set NombreCompletoCliente='" + nombre + "',MontoPagadoCliente='" + monto + "',DetalleCliente='" + detalle + "',silla1Cliente='" + silla1 + "',silla2Cliente='" + silla2 + "',silla3Cliente='" + silla3 + "',silla4Cliente='" + silla4 + "',List1Cliente='" + list1 + "',List2Cliente='" + list2 + "',List3Cliente='" + list3 + "',List4Cliente='" + list4 + "',FechaReservacion='" + FechaReservacion + "',EstadoPago='" + estado + "'WHERE CodigoCliente='" + id + "'";
            if (bd.executecommand(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public Boolean agregar_CajaRestaurante()
        {
            string[] valores = CodigoTabla("CodigoCaja", "CajasRestaurante");
            string codigo = encriptacion(valores[0]);
            string fecha = encriptacion(_fecha);
            string descripcion = encriptacion(_descripcion);
            string estrada = encriptacion(_entrada);
            string apertura = encriptacion(_montoApertura);
            string cierre = encriptacion(_montoCierre);
            string restaurante = encriptacion(_restaurante);

            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into CajasRestaurante(CodigoCaja,FechaRegistro,Descripcion,EntradaDinero,AperturaCaja,CierreCaja,RestauranteCaja) values ('" + codigo + "','" + fecha + "','" + descripcion + "','" + estrada + "','" + apertura + "','" + cierre + "','" + restaurante + "')";
            if (bd.executecommand(sql))
            {
                actualizarConsecutivos("CajasRestaurante", "PrefijoCaja", "Caja");

                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_bitacora()
        {
            string[] valores = CodigoTabla("CodigoBitacora", "Bitacora");
            string codigo = encriptacion(valores[0]);
            string fecha = encriptacion(_fecha);
            string user = encriptacion(_usuario);
            string descripcion = encriptacion(_descripcion);
            string detalle = encriptacion(_detalle);
        
            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Bitacora(CodigoBitacora,Usuario,Fecha,Descripcion,Detalle) values ('" + codigo + "','" + user + "','" + fecha + "','" + descripcion + "','" + detalle + "')";
            if (bd.executecommand(sql))
            {
                actualizarConsecutivos("Bitacora", "PrefijoBitacora", "Bitácora");

                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean agregar_Factura()
        {
            string[] valores = CodigoTabla("CodigoFactura", "Facturas");
            string codigo = encriptacion(valores[0]);
            string nombre = encriptacion(_nombre);
            string restaurante = encriptacion(_restaurante);
            string detalle = encriptacion(_detalle);
            string fecha = encriptacion(_fecha);
            string monto = encriptacion(_monto);
            string duracion = encriptacion(_tiempo);
            string estrada = encriptacion(_entrada);
            string salida = encriptacion(_salida);


            BaseDeDatos bd = new BaseDeDatos();
            string sql = "insert into Facturas(CodigoFactura,NombreCliente,NombreRestaurante,DetalleFactura,FechaFactura,MontoFactura,Duracion,HoraEntrada,HoraSalida) values ('" + codigo + "','" + nombre + "','" + restaurante + "','" + detalle + "','" + fecha + "','" + monto + "','" + duracion + "','" + estrada + "','" + salida + "')";
            if (bd.executecommand(sql))
            {
                actualizarConsecutivos("Facturas", "PrefijoFactura", "Facturas");

                return true;
            }
            else
            {
                return false;
            }
        }


        ///

        public string[] CodigoTabla(string codigo, string tabla)
        {
            string[] valores = new string[3];
            //TABLA CON LOS DATOS ENCRIPTADOS
            DataTable dt = new DataTable();
            Querys clogiga = new Querys();
            //TABLA QUEALACENARA LOS DATOS DESENCRIPTADOS
            DataTable modelo = new DataTable();
            //LENA LA TABLA DT CON LOS DATOS
            dt = bd.SelectDataTable("SELECT " + codigo + " FROM " + tabla + "").Copy();
            int codigoValor = 0;
            int valorObtenido = 0;
            string tipoConsecutivo = string.Empty;
            string valorFinal = string.Empty;

            //fiestaaaaa
            if (tabla.Equals("Restaurante"))
            {
                tipoConsecutivo = "Restaurantes";
            }
            if (tabla.Equals("Comestibles"))
            {
                tipoConsecutivo = "Comestibles";
            }
            if (tabla.Equals("Utencilios"))
            {
                tipoConsecutivo = "Equipos y Utensilios";
            }
            if (tabla.Equals("Tecnologias"))
            {
                tipoConsecutivo = "Tecnología";
            }
            if (tabla.Equals("Limpieza"))
            {
                tipoConsecutivo = "Limpieza e Higiene";
            }
            if (tabla.Equals("Desechables"))
            {
                tipoConsecutivo = "Desechables y Empaques";
            }
            if (tabla.Equals("Marcas"))
            {
                tipoConsecutivo = "Marcas";
            }
            if (tabla.Equals("Buffet"))
            {
                tipoConsecutivo = "Buffet";
            }
            if (tabla.Equals("BebidaCalientes"))
            {
                tipoConsecutivo = "Bebidas Calientes";
            }

            if (tabla.Equals("BebidaHeladas"))
            {
                tipoConsecutivo = "Bebidas Heladas";
            }

            if (tabla.Equals("BebidaGaseosas"))
            {
                tipoConsecutivo = "Bebidas Gaseosas";
            }
            if (tabla.Equals("Vinos"))
            {
                tipoConsecutivo = "Vinos";
            }
            if (tabla.Equals("Licores"))
            {
                tipoConsecutivo = "Licores";
            }
            if (tabla.Equals("Especiales"))
            {
                tipoConsecutivo = "Especiales";
            }
            if (tabla.Equals("Mesas"))
            {
                tipoConsecutivo = "Mesas";
            }
            if (tabla.Equals("Empleados"))
            {
                tipoConsecutivo = "Empleados";
            }
            if (tabla.Equals("Puestos"))
            {
                tipoConsecutivo = "Puestos";
            }
            if (tabla.Equals("Proveedores"))
            {
                tipoConsecutivo = "Proveedores";
            }
            if (tabla.Equals("Usuarios"))
            {
                tipoConsecutivo = "Usuarios";
            }
            if (tabla.Equals("Paises"))
            {
                tipoConsecutivo = "Países";
            }
            if (tabla.Equals("Roles"))
            {
                tipoConsecutivo = "Eventos o Roles";
            }
            if (tabla.Equals("UnidadesMedida"))
            {
                tipoConsecutivo = "Unidades de Medida";
            }
            if (tabla.Equals("Clientes"))
            {
                tipoConsecutivo = "Clientes";
            }
            if (tabla.Equals("CajasRestaurante"))
            {
                tipoConsecutivo = "Caja";
            }
            if (tabla.Equals("Facturas"))
            {
                tipoConsecutivo = "Facturas";
            }
            if (tabla.Equals("Bitacora"))
            {
                tipoConsecutivo = "Bitácora";
            }
            //end fiesta

            string prefijo = bd.selectstring("SELECT  PrefijoConsecutivo  FROM  Consecutivos where TipoConsecutivo = '" + encriptacion(tipoConsecutivo) + "'");
            if (string.IsNullOrEmpty(prefijo))
            {
                prefijo = string.Empty;
            }
            else
            {
                prefijo = desencriptacion(prefijo);
            }
            //comprueba s hay valor en la tabla
            string COND = bd.selectstring("SELECT top 1 " + codigo + " from " + tabla + " order by " + codigo + " desc");
            string valorInicial = bd.selectstring("SELECT  ValorConsecutivo  FROM  Consecutivos where TipoConsecutivo = '" + encriptacion(tipoConsecutivo) + "'");
            if (string.IsNullOrEmpty(COND))
            {  
                //Sin valor inicial
                if (string.IsNullOrEmpty(valorInicial))
                {
                    codigoValor = 1;
                    valorFinal = codigoValor.ToString();

                    valores[0] = codigoValor.ToString();
                    valores[1] = valorFinal;
                    valores[2] = codigoValor.ToString();

                    return valores;
                }
                    //con valor inical
                else
                {
                    codigoValor = int.Parse(desencriptacion(valorInicial));
                    valorFinal = prefijo + codigoValor.ToString();
                    
                    valores[0] = codigoValor.ToString();
                    valores[1] = valorFinal;
                    //factura sin sumar +1
                    valores[2] = valorFinal;

                    return valores;
                }

            }
            //cuenta quien es mayor
            foreach (DataRow row in dt.Rows)
            {

                    int valor = int.Parse(desencriptacion(row[0].ToString()));
                    if (valor > valorObtenido)
                    {
                        valorObtenido = valor;
                    }
  
            }
            //comprueba si el se cambio el valor inicial, y si es mayor a la lista de los actuales, pare empezar a a contra desde el maytor
            if (!string.IsNullOrEmpty(valorInicial))
            {
                if (valorObtenido < int.Parse(desencriptacion(valorInicial)))
                {
                    codigoValor = int.Parse(desencriptacion(valorInicial));
                    valores[0] = codigoValor.ToString();
                    valores[1] = prefijo + codigoValor.ToString();
                    valores[2] = prefijo + codigoValor.ToString();
                    return valores;
                }
            }
            //ya cuando hay valores en la tabla
            codigoValor = valorObtenido + 1;

            valores[0] = codigoValor.ToString();
            valores[1] = prefijo + codigoValor.ToString();
            valores[2] = prefijo + (codigoValor - 1).ToString();

            return valores;
        }

        ////






        public void actualizarTablaConsecutivos()
        {
            actualizarConsecutivos("Restaurante", "PrefijoRestaurante", "Restaurantes");
            actualizarConsecutivos("Comestibles", "PrefijoComestible", "Comestibles");
            actualizarConsecutivos("Utencilios", "PrefijoUtencilios", "Equipos y Utensilios");
            actualizarConsecutivos("Tecnologias", "PrefijoTecnologia", "Tecnología");
            actualizarConsecutivos("Limpieza", "PrefijoLimpieza", "Limpieza e Higiene");
            actualizarConsecutivos("Desechables", "PrefijoDesechable", "Desechables y Empaques");
            actualizarConsecutivos("Marcas", "PrefijoMarca", "Marcas");
            actualizarConsecutivos("Restaurante", "PrefijoRestaurante", "Restaurantes");
            actualizarConsecutivos("Buffet", "PrefijoBuffet", "Buffet");
            actualizarConsecutivos("BebidaCalientes", "PrefijoBebidaCaliente", "Bebidas Calientes");
            actualizarConsecutivos("BebidaHeladas", "PrefijoBebidaHelada", "Bebidas Heladas");
            actualizarConsecutivos("BebidaGaseosas", "PrefijoBebidaGaseosa", "Bebidas Gaseosas");
            actualizarConsecutivos("Vinos", "PrefijoVino", "Vinos");
            actualizarConsecutivos("Licores", "PrefijoLicor", "Licores");
            actualizarConsecutivos("Especiales", "PrefijoEspecial", "Especiales");
            actualizarConsecutivos("Mesas", "PrefijoMesa", "Mesas");
            actualizarConsecutivos("Empleados", "PrefijoEmpleado", "Empleados");
            actualizarConsecutivos("Puestos", "PrefijoPuesto", "Puestos");
            actualizarConsecutivos("Proveedores", "PrefijoProveedor", "Proveedores");
            actualizarConsecutivos("Usuarios", "PrefijoUsuario", "Usuarios");
            actualizarConsecutivos("Paises", "PrefijoPais", "Países");
            actualizarConsecutivos("Roles", "PrefijoRol", "Eventos o Roles");
            actualizarConsecutivos("UnidadesMedida", "PrefijoMedida", "Unidades de Medida");
            actualizarConsecutivos("Clientes", "PrefijoCliente", "Clientes");
            actualizarConsecutivos("CajasRestaurante", "PrefijoCaja", "Caja");//no esta en la lista PDF
            actualizarConsecutivos("Facturas", "PrefijoFactura", "Facturas");
            actualizarConsecutivos("Bitacora", "PrefijoBitacora", "Bitácora");
        }
        private void actualizarConsecutivos(string tabla, string columna,string tipo)
        {
            string prefijo = bd.selectstring("select PrefijoConsecutivo from Consecutivos where TipoConsecutivo = '" + encriptacion(tipo) + "'").ToString();
            if (string.IsNullOrEmpty(prefijo))
            {
                return;
            }

            bd.executecommand("update " + tabla + " set " + columna + " = '" + prefijo + "'");
        }
        #endregion
    }
}
