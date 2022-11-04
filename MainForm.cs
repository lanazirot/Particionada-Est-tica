using System;
using System.Windows.Forms;
using System.Linq;
using ZedGraph;
using System.Drawing;
using ByteSizeLib;
using System.Collections.Generic;

namespace Particionada_Estática {
    public partial class MainForm : Form {

        private Memoria memoria;

        public MainForm() {
            InitializeComponent();
            InitializeMemoria();
            graficaMemoria.IsShowPointValues = true;
        }

        private void RefrescarGrafica() {
            var tipo = cboMemoriaTotal.SelectedItem.ToString();
            var myPane = graficaMemoria.GraphPane;
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();
            myPane.BarSettings.Type = BarType.Stack;
            myPane.Title.Text = "Grafica Memoria";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "Particiones";
            string[] labels = { "Memoria" };

            Particion SO = memoria.Particiones.Where(p => p.Numero == 0).FirstOrDefault();

            double res0 = 0;
            switch (tipo) {
                case "GB":
                    res0 = ByteSize.FromKibiBytes(SO.Tamano).GibiBytes;
                    break;
                case "MB":
                    res0 = ByteSize.FromKibiBytes(SO.Tamano).MebiBytes;
                    break;
                case "KB":
                    res0 = ByteSize.FromKibiBytes(SO.Tamano).KibiBytes;
                    break;
                default:
                    break;
            }


            var tituloSO = $"S.O";
            var ocupadaSO = Color.Aqua;
            double[] valorParticionSO = { res0 };
            BarItem barx = myPane.AddBar(tituloSO, null, valorParticionSO, ocupadaSO);
            barx.Bar.Fill = new Fill(ocupadaSO);




            foreach (Particion particion in memoria.Particiones.Where(p => p.Status != Particion.EstadoParticion.SOBRANTE && p.Numero != 0 && p.Numero != -1)) {
                var strTitle = $"P.{particion.Numero}";
                var ocupada = particion.Status == Particion.EstadoParticion.DISPONIBLE ? Color.Green : Color.Red;


                if (particion.Trabajos.Count > 0) {
                    double calculoTrabajo = particion.Tamano - particion.Trabajos[0].Tamano;

                    double res = 0;
                    switch (tipo) {
                        case "GB":
                            res = ByteSize.FromKibiBytes(particion.Trabajos[0].Tamano).GibiBytes;
                            break;
                        case "MB":
                            res = ByteSize.FromKibiBytes(particion.Trabajos[0].Tamano).MebiBytes;
                            break;
                        case "KB":
                            res = ByteSize.FromKibiBytes(particion.Trabajos[0].Tamano).KibiBytes;
                            break;
                        default:
                            break;
                    }

                    double[] valorTrabajo = { res };
                    BarItem bart = myPane.AddBar(particion.Trabajos[0].ID, null, valorTrabajo, Color.HotPink);
                    bart.Bar.Fill = new Fill(Color.HotPink);

                    if (calculoTrabajo != 0) {

                        double res2 = 0;
                        switch (tipo) {
                            case "GB":
                                res2 = ByteSize.FromKibiBytes(calculoTrabajo).GibiBytes;
                                break;
                            case "MB":
                                res2 = ByteSize.FromKibiBytes(calculoTrabajo).MebiBytes;
                                break;
                            case "KB":
                                res2 = ByteSize.FromKibiBytes(calculoTrabajo).KibiBytes;
                                break;
                            default:
                                break;
                        }

                        double[] valorParticion = { res2 };
                        BarItem bar = myPane.AddBar("R." + particion.Numero, null, valorParticion, Color.Gray);
                        bar.Bar.Fill = new Fill(Color.Gray);
                    }
                } else {

                    double res3 = 0;
                    switch (tipo) {
                        case "GB":
                            res3 = ByteSize.FromKibiBytes(particion.Tamano).GibiBytes;
                            break;
                        case "MB":
                            res3 = ByteSize.FromKibiBytes(particion.Tamano).MebiBytes;
                            break;
                        case "KB":
                            res3 = ByteSize.FromKibiBytes(particion.Tamano).KibiBytes;
                            break;
                        default:
                            break;
                    }

                    double[] valorParticion = { res3 };
                    BarItem bar = myPane.AddBar(strTitle, null, valorParticion, ocupada);
                    bar.Bar.Fill = new Fill(ocupada);
                }
            }




            Particion sobrante = memoria.Particiones.Where(p => p.Numero == -1).FirstOrDefault();


            double res4 = 0;
            switch (tipo) {
                case "GB":
                    res4 = ByteSize.FromKibiBytes(sobrante.Tamano).GibiBytes;
                    break;
                case "MB":
                    res4 = ByteSize.FromKibiBytes(sobrante.Tamano).MebiBytes;
                    break;
                case "KB":
                    res4 = ByteSize.FromKibiBytes(sobrante.Tamano).KibiBytes;
                    break;
                default:
                    break;
            }

            if (res4 > 0) {
                var tituloSobrante = "SOBRANTE";
                var ocupadaSobrante = Color.LightGreen;
                double[] valorSobrante = { res4 };
                BarItem barSobrante = myPane.AddBar(tituloSobrante, null, valorSobrante, ocupadaSobrante);
                barSobrante.Bar.Fill = new Fill(ocupadaSobrante);
            }

            myPane.XAxis.MajorTic.IsBetweenLabels = true;
            myPane.XAxis.Scale.TextLabels = labels;
            myPane.XAxis.Type = AxisType.Text;
            myPane.Chart.Fill = new Fill(Color.White,
                  Color.FromArgb(255, 255, 166), 90F);
            myPane.Fill = new Fill(Color.FromArgb(250, 250, 255));
            graficaMemoria.AxisChange();
            Utils.CreateBarLabels(myPane, true, "f2");
            graficaMemoria.Refresh();
        }




        private void InitializeMemoria() {
            memoria = new Memoria();
        }

        private void btnComenzarSimulacion_Click(object sender, EventArgs e) {

            if (memoria == null || memoria.TamanoMemoria == -1) {
                MessageBox.Show("Memoria aun no asignada. Imposible empezar a capturar particiones");
                return;
            }

            if (memoria.Trabajos.Count > 0) {
                MessageBox.Show("Error", "Trabajos ya estan siendo asignados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listLog.Items.Add("[ERROR] Trabajos en memoria");
                return;
            }

            int numeroParticiones;
            try {
                numeroParticiones = int.Parse(txtParticiones.Text);
                memoria.NumeroParticiones = numeroParticiones;
            } catch (Exception) {
                MessageBox.Show("Capture numero de particiones");
                return;
            }

            int i = 1;

            if (memoria.Particiones.Where(p => p.Numero != -1 && p.Numero != 0).Any()) {
                i = memoria.Particiones.Where(p => p.Numero != -1 && p.Numero != 0).Count() + 1;
                numeroParticiones = i + numeroParticiones;
            } else numeroParticiones++;

            var list = new List<Particion>();
            
            for (; i < numeroParticiones; i++) {
                Particion part = null;
                bool capturada = true;
                do {
                    part = new Particion {
                        Numero = i,
                        Tamano = Utils.KB(ShowDialog($"Capture particion {i}", "Captura de particiones", out string tipo), tipo),
                        Desperdicio = 0,
                        Status = Particion.EstadoParticion.DISPONIBLE
                    };
                    if (part.Tamano > memoria.TamanoMemoriaDisponible) {
                        MessageBox.Show("Vuelva a capturar una particion con tamano menor al tamano de memoria disponible", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        capturada = false;
                    } else capturada = true;
                } while (!capturada);

                list.Add(part);
                memoria.Particiones.Add(part);

            }

            Particion sobrante = memoria.Particiones.Where(p => p.Status == Particion.EstadoParticion.SOBRANTE).FirstOrDefault();

            if (sobrante != null) {
                sobrante.Tamano -=
                    list.Where(p => p.Status == Particion.EstadoParticion.DISPONIBLE).Sum(p => p.Tamano);
            }


            RefreshParticionesTable();
            CargarProgressBarMemoria();
            listLog.Items.Add("[INFO] Particiones capturadas correctamente.");
            ShowMemoria();
        }

        private void ShowMemoria() {
            if (memoria != null)
                lblSENA.Text = "Memoria disponible: " + ByteSize.FromKibiBytes(memoria.TamanoMemoriaDisponible).ToBinaryString();
            else lblSENA.Text = "Memoria disponible: ";
        }

        private static double ShowDialog(string text, string caption, out string tipo) {
            Form prompt = new() {
                Width = 500,
                Height = 200,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                ControlBox = false
            };
            System.Windows.Forms.Label textLabel = new() { Left = 50, Top = 20, Text = text };
            TextBox inputBox = new() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new() { Text = "Capturar", Left = 350, Width = 100, Top = 90 };
            ComboBox cboTipoDato = new() {
                Items = { "KB", "MB", "GB" }, Left = 150, Width = 100, Top = 90, SelectedIndex = 0,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(cboTipoDato);
            prompt.ShowDialog();
            tipo = cboTipoDato.SelectedItem.ToString();
            return double.Parse(inputBox.Text);
        }


        private void btnCapturarTrabajos_Click(object sender, EventArgs e) {
            Trabajo job;
            try {
                job = new() {
                    Estado = Trabajo.EstadoTrabajo.ESPERA,
                    ID = txtIDTrabajo.Text,
                    Tamano = Utils.KB(double.Parse(txtValorTrabajo.Text), cboTrabajo.SelectedItem.ToString())
                };
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error en la captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtIDTrabajo.Clear();
            txtValorTrabajo.Clear();
            txtIDTrabajo.Focus();
            OnJobAdded(job);
        }

        private void OnJobAdded(Trabajo job) {
            if (memoria == null || memoria.NoAsignada || !memoria.ConParticiones) {
                MessageBox.Show("Memoria aun no asignada o falta capturar particiones", "Error en captura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Buscar el trabajo entre los establecidos
            var find = memoria.Trabajos.Where(t => t.ID.Equals(job.ID)).FirstOrDefault();
            if (find != null && find.Estado == Trabajo.EstadoTrabajo.MUERTO) {
                listLog.Items.Add($"[WARNING] Se intento capturar un trabajo muerto {find.ID}");
                return;
            }

            if (find != null && find.Estado == Trabajo.EstadoTrabajo.ESPERA) {
                find.Estado = Trabajo.EstadoTrabajo.MUERTO;
                memoria.TrabajosEnCola.Remove(find);
                listLog.Items.Add($"[INFO] Se libero el trabajo de la cola espera {find.ID}");
                RefreshJobsTable();
                RefreshParticionesTable();
                CargarProgressBarMemoria();
                return;
            }

            //Encontramos el trabajo en la lista
            if (find != null && find.Estado == Trabajo.EstadoTrabajo.ASIGNADO) {
                find.Estado = Trabajo.EstadoTrabajo.MUERTO; //Liberamos el trabajo
                listLog.Items.Add($"[INFO] Se libero el trabajo {find.ID}");
                memoria.Particiones.Where(p => p.Numero == find.Particion.Numero).
                    First().Status = Particion.EstadoParticion.DISPONIBLE;
                memoria.Particiones.Where(p => p.Numero == find.Particion.Numero).
                    First().Desperdicio = 0;
                memoria.Particiones.Where(p => p.Numero == find.Particion.Numero).
                    First().Trabajos.Remove(job);
                listLog.Items.Add($"[INFO] Particion { memoria.Particiones.Where(p => p.Numero == find.Particion.Numero).First().Numero} liberada");
                RefreshJobsTable();
                RefreshParticionesTable();
                CargarProgressBarMemoria();
                if (AsignarTrabajosEnColaExistentes()) {
                    MessageBox.Show("Trabajo asignado desde cola debido a liberacion de particion", "Notificacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }


            double max = memoria.Particiones.Where(p => p.Numero != -1 && p.Numero != 0).Max(p => p.Tamano);
            memoria.Trabajos.Add(job);
            if (job.Tamano > max) {
                job.Estado = Trabajo.EstadoTrabajo.NUNCA;
                MessageBox.Show("El trabajo jamas va a ser atendido. No existe una particion con tamano adecuado", "Notificacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                listLog.Items.Add($"[ERROR] Error en proceso {job.ID} jamas sera atendido");
            } else {
                foreach (Particion particion in memoria.Particiones) {
                    if (particion.Tamano >= job.Tamano) {
                        if (particion.Status == Particion.EstadoParticion.DISPONIBLE) {
                            particion.Status = Particion.EstadoParticion.OCUPADO;
                            job.Estado = Trabajo.EstadoTrabajo.ASIGNADO;
                            particion.Desperdicio = particion.Tamano - job.Tamano;
                            job.Particion = particion;
                            particion.Trabajos.Add(job);
                            listLog.Items.Add($"[INFO] Se asigno el trabajo {job.ID} a la particion {particion.Numero}");
                            break;
                        }
                    }
                }
                if (job.Estado == Trabajo.EstadoTrabajo.ESPERA) {
                    memoria.TrabajosEnCola.Add(job);
                    listLog.Items.Add($"[INFO] El trabajo {job.ID} fue ingresado a la cola de espera");
                }
            }
            CargarProgressBarMemoria();
            RefreshParticionesTable();
            RefreshJobsTable();
        }

        private bool AsignarTrabajosEnColaExistentes() {
            bool proceso = false;
            if (memoria.TrabajosEnCola.Count > 0) {

                foreach (Particion particion in memoria.Particiones) {
                    Trabajo job = memoria.TrabajosEnCola.Where(t => particion.Tamano >= t.Tamano).FirstOrDefault();
                    if (job != null && job.Estado == Trabajo.EstadoTrabajo.ESPERA) {
                        if (particion.Status == Particion.EstadoParticion.DISPONIBLE) {
                            particion.Status = Particion.EstadoParticion.OCUPADO;
                            job.Estado = Trabajo.EstadoTrabajo.ASIGNADO;
                            particion.Desperdicio = particion.Tamano - job.Tamano;
                            job.Particion = particion;
                            proceso = true;
                            particion.Trabajos.Add(job);
                            memoria.TrabajosEnCola.Remove(job);
                            CargarProgressBarMemoria();
                            RefreshParticionesTable();
                            RefreshJobsTable();
                            listLog.Items.Add($"[INFO] Trabajo {job.ID} fue asignado desde la cola de espera a la particion {particion.Numero}");
                            break;
                        }
                    }
                }
            }
            return proceso;
        }

        private void RefreshJobsTable() {
            dtgRelTrabajoParticion.Rows.Clear();
            foreach (Trabajo job in memoria.Trabajos) {
                dtgRelTrabajoParticion.Rows.Add(job.ID, ByteSize.FromKibiBytes(job.Tamano).ToBinaryString(), 
                    job.Particion == null || job.Estado == Trabajo.EstadoTrabajo.MUERTO ? "N/A" : job.Particion.Numero, job.Estado);
            }
        }

        private void RefreshParticionesTable() {
            dtgParticiones.Rows.Clear();
            foreach (Particion particion in memoria.Particiones) {
                if (particion.Status == Particion.EstadoParticion.SOBRANTE) continue;
                dtgParticiones.Rows.Add(particion.Numero == 0 ? "S.O" : particion.Numero,
                    ByteSize.FromKibiBytes(particion.Tamano).ToBinaryString(), particion.Status.ToString(), ByteSize.FromKibiBytes(particion.Desperdicio).ToBinaryString(),
                    particion.Trabajos.Count == 0 ? "N/A" : particion.Trabajos[0].ID);
            }
        }
        private void btnEmpezarSimulacion_Click(object sender, EventArgs e) {
            var itemSO = cboMemoriaSO.SelectedItem;
            var itemMem = cboMemoriaTotal.SelectedItem;
            double tamanoSO = Utils.KB(double.Parse(txtMemoriaOS.Text), itemSO.ToString());
            double tamanoMemoria = Utils.KB(double.Parse(txtMemoriaTotal.Text), itemMem.ToString());
            dtgParticiones.Rows.Clear();
            dtgRelTrabajoParticion.Rows.Clear();
            try {
                InitializeMemoria();
                memoria.TamanoMemoria = tamanoMemoria;
                memoria.TamanoSistemaOperativo = tamanoSO;
                CargarProgressBarMemoria();
                RefreshParticionesTable();
                EnableInputsMemoria(false);
                ShowMemoria();
                listLog.Items.Add($"[INFO] Memoria establecida en {ByteSize.FromKibiBytes(memoria.TamanoMemoria).ToBinaryString()} y el SO establecido en {ByteSize.FromKibiBytes(memoria.TamanoSistemaOperativo).ToBinaryString()}");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error al comenzar simulacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void CargarProgressBarMemoria() {
            RefrescarGrafica();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            cboMemoriaSO.SelectedIndex = 0;
            cboMemoriaTotal.SelectedIndex = 0;
            cboTrabajo.SelectedIndex = 0;
            cboNuevaParticion.SelectedIndex = 0;
            ClearGraph();
        }

        private void ClearGraph() {
            GraphPane myPane = graficaMemoria.GraphPane;
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();
            myPane.BarSettings.Type = BarType.Stack;
            myPane.Title.Text = "Grafica Memoria";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "Particiones";
            graficaMemoria.Refresh();

        }

        private void EnableInputsMemoria(bool enabled) {
            txtMemoriaOS.Enabled = enabled;
            txtMemoriaTotal.Enabled = enabled;
            btnEmpezarSimulacion.Enabled = enabled;
        }

        private void EnableInputParticiones(bool enabled) {
            txtParticiones.Enabled = enabled;
            btnCapturarParticiones.Enabled = enabled;
        }

        private void btnReset_Click(object sender, EventArgs e) {
            memoria = null;
            ShowMemoria();
            listLog.Items.Clear();
            txtMemoriaTotal.Clear();
            txtMemoriaOS.Clear();
            txtParticiones.Clear();
            EnableInputsMemoria(true);
            EnableInputParticiones(true);
            dtgParticiones.Rows.Clear();
            dtgRelTrabajoParticion.Rows.Clear();
            ClearGraph();
        }

        private string graficaMemoria_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt) {
            return $"{curve.Label.Text}";
        }

        private void BtnNuevaParticion_Click(object sender, EventArgs e) {

            if (memoria.Trabajos.Count > 0) {
                MessageBox.Show("Error", "Trabajos ya estan siendo asignados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listLog.Items.Add("[ERROR] Trabajos en memoria");
                return;
            }

            try {
                Particion part = new() {
                    Numero = memoria.Particiones.Count - 1,
                    Tamano = Utils.KB(double.Parse(txtNuevaParticion.Text), cboNuevaParticion.SelectedItem.ToString()),
                    Desperdicio = 0,
                    Status = Particion.EstadoParticion.DISPONIBLE
                };
                if (part.Tamano > memoria.TamanoMemoriaDisponible) {
                    MessageBox.Show("Vuelva a capturar una particion con tamano menor al tamano de memoria disponible", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    memoria.Particiones.Add(part);
                    Particion sobrante = memoria.Particiones.Where(p => p.Status == Particion.EstadoParticion.SOBRANTE).FirstOrDefault();

                    if (sobrante != null) {
                        sobrante.Tamano -= part.Tamano;
                    }
                    RefreshParticionesTable();
                    CargarProgressBarMemoria();
                    listLog.Items.Add($"[INFO] Particion {part.Numero} capturada correctamente.");
                    ShowMemoria();
                    txtNuevaParticion.Clear();
                    txtNuevaParticion.Focus();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error en captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNuevaParticion.Focus();
            }
        }
    }
}
