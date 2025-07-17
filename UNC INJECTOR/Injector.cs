using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace UNC_INJECTOR
{
    public partial class Injector : Form
    {
        // Lista para armazenar os caminhos das DLLs
        private List<string> dllList = new List<string>();

        // Importações para injeção por APC
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenThread(int dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint QueueUserAPC(IntPtr pfnAPC, IntPtr hThread, IntPtr dwData);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        public Injector()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void Injector_Load(object sender, EventArgs e)
        {
            // Configurar o ListBox para não permitir edição
            ListDLL.SelectionMode = SelectionMode.One;
        }

        private void ListDLL_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Este método é chamado quando uma DLL é selecionada na lista
            if (ListDLL.SelectedIndex >= 0)
            {
                string selectedDll = ListDLL.SelectedItem.ToString();
                // Aqui você pode adicionar lógica adicional quando uma DLL é selecionada
                // Por exemplo, mostrar informações da DLL, habilitar botões, etc.
            }
        }

        private void DlladdButton_Click(object sender, EventArgs e)
        {
            // Criar uma instância do OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            // Configurar as propriedades do diálogo
            openFileDialog.Title = "Selecionar DLL";
            openFileDialog.Filter = "Arquivos DLL (*.dll)|*.dll|Todos os arquivos (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            
            // Mostrar o diálogo e verificar se o usuário selecionou um arquivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Obter o caminho do arquivo selecionado
                    string selectedFilePath = openFileDialog.FileName;
                    
                    // Verificar se a DLL já está na lista
                    if (!string.IsNullOrEmpty(selectedFilePath))
                    {
                        if (!dllList.Contains(selectedFilePath))
                        {
                            // Adicionar à lista interna
                            dllList.Add(selectedFilePath);
                            
                            // Adicionar ao ListBox (mostrar apenas o nome do arquivo)
                            string fileName = System.IO.Path.GetFileName(selectedFilePath);
                            ListDLL.Items.Add(fileName);
                            
                            // Opcional: Mostrar uma mensagem de confirmação
                            MessageBox.Show($"DLL adicionada: {fileName}", 
                                         "DLL Adicionada", 
                                           MessageBoxButtons.OK, 
                                           MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Esta DLL já está na lista!", 
                                           "DLL Duplicada", 
                                           MessageBoxButtons.OK, 
                                           MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao selecionar a DLL: {ex.Message}", 
                 "Erro", 
                                   MessageBoxButtons.OK, 
                                   MessageBoxIcon.Error);
                }
            }
        }

        private void DllRemoveButton_Click(object sender, EventArgs e)
        {
            // Remover a DLL selecionada da lista
            if (ListDLL.SelectedIndex >= 0)
            {
                int selectedIndex = ListDLL.SelectedIndex;
                
                // Remover da lista interna
                dllList.RemoveAt(selectedIndex);
                
                // Remover do ListBox
                ListDLL.Items.RemoveAt(selectedIndex);
                
                MessageBox.Show("DLL removida da lista!", 
                             "DLL Removida", 
                               MessageBoxButtons.OK, 
                               MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Selecione uma DLL para remover!", 
                             "Nenhuma DLL Selecionada", 
                               MessageBoxButtons.OK, 
                               MessageBoxIcon.Warning);
            }
        }

        // Método de injeção por APC (mais furtivo)
        public bool InjectDllAPC(string processName, string dllPath)
        {
            try
            {
                var targetProcess = Process.GetProcessesByName(processName).FirstOrDefault();
                if (targetProcess == null)
                {
                    MessageBox.Show("Processo não encontrado!");
                    return false;
                }

                IntPtr hProcess = OpenProcess(0x1F0FFF, false, targetProcess.Id);
                if (hProcess == IntPtr.Zero)
                {
                    MessageBox.Show("Falha ao abrir o processo!");
                    return false;
                }

                IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)((dllPath.Length +1) * Marshal.SizeOf(typeof(char))), 0x10 | 0x2000, 0x40);
                if (allocMemAddress == IntPtr.Zero)
                {
                    MessageBox.Show("Falha ao alocar memória no processo alvo!");
                    CloseHandle(hProcess);
                    return false;
                }

                byte[] bytes = Encoding.Unicode.GetBytes(dllPath);
                WriteProcessMemory(hProcess, allocMemAddress, bytes, (uint)bytes.Length, out _);

                IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"),"LoadLibraryW");
                if (loadLibraryAddr == IntPtr.Zero)
                {
                    MessageBox.Show("Falha ao obter endereço do LoadLibraryW!");
                    CloseHandle(hProcess);
                    return false;
                }

                // Injeta em todas as threads do processo alvo
                foreach (ProcessThread thread in targetProcess.Threads)
                {
                    IntPtr hThread = OpenThread(0x0010 | 0x0008 | 0x0020, false, (uint)thread.Id);
                    if (hThread != IntPtr.Zero)
                    {
                        QueueUserAPC(loadLibraryAddr, hThread, allocMemAddress);
                        CloseHandle(hThread);
                    }
                }

                CloseHandle(hProcess);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao injetar DLL: {ex.Message}");
                return false;
            }
        }

        private void InjectButton_Click(object sender, EventArgs e)
        {
            string dllPath = GetSelectedDllPath();
            if (dllPath == null)
            {
                MessageBox.Show("Selecione uma DLL para injetar!");
                return;
            }

            string processName = Interaction.InputBox("Digite o nome do processo alvo (sem .exe):", "Processo Alvo", "notepad");
            if (string.IsNullOrWhiteSpace(processName))
                return;

            if (InjectDllAPC(processName, dllPath))
                MessageBox.Show("DLL injetada (APC) com sucesso!");
        }

        // Método para obter o caminho completo da DLL selecionada
        public string GetSelectedDllPath()
        {
            if (ListDLL.SelectedIndex >= 0)
            {
                return dllList[ListDLL.SelectedIndex];
            }
            return null;
        }

        // Método para obter todas as DLLs da lista
        public List<string> GetAllDllPaths()
        {
            return new List<string>(dllList);
        }
    }
} 