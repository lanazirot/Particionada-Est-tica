using System;
using System.Collections.Generic;
using System.Linq;


namespace Particionada_Estática {
    class Memoria {

        /// <summary>
        /// Todo se maneja en KB en la memoria. Conversiones, etc.
        /// </summary>
        //LZ 5 11 2021
        public double TamanoMemoria { get; set; }
        private double _tamanoSistemaOperativo;
        public double TamanoSistemaOperativo {
            get => _tamanoSistemaOperativo;
            set {
                var treintaPorcientoMemoria = TamanoMemoria * 0.30;
                if (value > treintaPorcientoMemoria)
                    throw new Exception("El tamaño de memoria del sistema operativo no puede exceder el 30% de " +
                        "la memoria total.");
                _tamanoSistemaOperativo = value;
                var partSO = new Particion() {
                    Numero = 0,
                    Status = Particion.EstadoParticion.OCUPADO,
                    Desperdicio = 0,
                    Tamano = value
                };

                var partSobrante = new Particion() {
                    Numero = -1,
                    Status = Particion.EstadoParticion.SOBRANTE,
                    Desperdicio = 0,
                    Tamano = TamanoMemoria - value
                };


                if (Particiones == null) {
                    Particiones = new List<Particion> {
                       partSO, partSobrante
                    };
                } else { Particiones.Add(partSO); Particiones.Add(partSobrante); }
            }
        }

        public int NumeroParticiones {
            get; set;
        }
        public int NumeroTrabajos {
            get; set;
        }

        public List<Particion> Particiones {
            get;set;
        }

        public List<Trabajo> Trabajos {
            get;set;
        }


        public Memoria(int tamanioMemoriaTotal) {
            TamanoMemoria = tamanioMemoriaTotal;
        }

        public Memoria() {
            Trabajos = new List<Trabajo>();
            TrabajosEnCola = new List<Trabajo>();
            Particiones = new List<Particion>();
            TamanoMemoria = -1;
        }

        public double TamanoMemoriaOcupada => Trabajos != null ? TamanoSistemaOperativo + Particiones.Where(p=>p.Numero!=0 && p.Numero!=-1).Sum(t => t.Tamano) : TamanoSistemaOperativo;

        public double TamanoMemoriaDisponible {
            get {
                return Particiones != null ?
                    TamanoMemoria - (TamanoSistemaOperativo + Particiones.Where(p => p.Status == Particion.EstadoParticion.DISPONIBLE).Sum(p => p.Tamano)) :
                    TamanoMemoria - TamanoSistemaOperativo;
            }
        }

        public List<Trabajo> TrabajosEnCola {
            get;set;
        }

        public bool NoAsignada => TamanoMemoria == -1;

        public bool ConParticiones => Particiones != null && Particiones.Where(p=> p.Numero!=0 && p.Numero!=-1).Count() > 0;

    }


    class Trabajo : IEquatable<Trabajo>, IComparable<Trabajo>{

        public string ID {
            get; set;
        }

        public double Tamano {
            get; set;
        }

        public EstadoTrabajo Estado {
            get; set;
        }

        public enum EstadoTrabajo {
            ESPERA, NUNCA, ASIGNADO, MUERTO
        }

        public Particion Particion {
            get; set;
        }

        public bool Equals(Trabajo other) {
            return ID.Equals(other.ID);
        }

        public int CompareTo(Trabajo other) {
            return ID.CompareTo(other.ID);
        }
    }

    class Particion {

        public int Numero {
            get; set;
        }

        public double Tamano {
            get; set;
        }

        public double Desperdicio {
            get; set;
        }

        public EstadoParticion Status {
            get; set;
        }

        public enum EstadoParticion {
            OCUPADO, DISPONIBLE, SOBRANTE
        }   

        public List<Trabajo> Trabajos {
            get;set;
        }

        public Particion() {
            Trabajos = new List<Trabajo>();
        }

    }

}
