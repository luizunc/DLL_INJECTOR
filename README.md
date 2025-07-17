# UNC INJECTOR

Um injetor de DLL básico desenvolvido em C#, com interface gráfica moderna, utilizando técnicas de injeção furtiva para máxima eficiência.

---

## 🚀 Características

- **Interface Moderna**: Interface gráfica elegante usando Guna.UI2  
- **Injeção Furtiva**: Utiliza a técnica APC (Asynchronous Procedure Call) para injeção menos detectável  
- **Gerenciamento de DLLs**: Sistema de lista para gerenciar múltiplas DLLs  
- **Seleção Intuitiva**: ListBox com nomes de arquivos para fácil identificação  
- **Prevenção de Duplicatas**: Evita adicionar a mesma DLL múltiplas vezes  
- **Interface Responsiva**: Design adaptável e fácil de usar  

---

## 📋 Pré-requisitos

- **.NET Framework 4.8** ou superior  
- **Windows 10/11**  
- **Visual Studio 2019/2022** (para compilação)  

---

## 🛠️ Dependências

- **Guna.UI2.WinForms** (v2.0.4.7) – Interface gráfica moderna  
- **Microsoft.VisualBasic** – Para funcionalidades de entrada de dados  
- **System.Windows.Forms** – Componentes de interface  

---

## 📦 Instalação

### 🔹 Opção 1: Executável Pré-compilado

1. Baixe o arquivo `UNC INJECTOR.exe` da pasta `bin/x64/Release/`  
2. Execute o arquivo diretamente  

### 🔹 Opção 2: Compilar do Código-Fonte

1. Clone ou baixe este repositório  
2. Abra o arquivo `UNC INJECTOR.csproj` no Visual Studio  
3. Restaure os pacotes NuGet (Guna.UI2.WinForms)  
4. Compile o projeto (`Ctrl + Shift + B`)  
5. Execute o aplicativo  

---

## 🎯 Como Usar

### 1. Adicionar DLLs

- Clique no botão **"Select DLL"**  
- Navegue até a pasta onde está sua DLL  
- Selecione o arquivo `.dll` desejado  
- A DLL será adicionada à lista com confirmação  

### 2. Gerenciar DLLs

- **Visualizar**: As DLLs aparecem na lista com seus nomes de arquivo  
- **Selecionar**: Clique em uma DLL na lista para selecioná-la  
- **Remover**: Selecione uma DLL e clique em **"Remove DLL"**  

### 3. Injetar DLL

- Selecione a DLL desejada na lista  
- Clique no botão **"INJECT"**  
- Digite o nome do processo alvo (ex: `notepad`, `chrome`, etc.)  
- Aguarde a confirmação de injeção bem-sucedida  

---

## 🔧 Funcionalidades Técnicas

### Injeção por APC (Asynchronous Procedure Call)

O aplicativo utiliza uma técnica de injeção mais furtiva do que o método tradicional:

- **Menos Detectável**: Evita detecção por alguns antivírus e anticheats  
- **Injeção em Threads**: Injeta a DLL em todas as threads do processo alvo  
- **Alocação de Memória**: Aloca memória no processo alvo de forma segura  
- **QueueUserAPC**: Utiliza a API `QueueUserAPC` para injeção assíncrona  

---

## 🗂️ Estrutura do Código

```
UNC INJECTOR/
├── Injector.cs             # Lógica principal e injeção
├── Injector.Designer.cs   # Interface gráfica
├── Injector.resx          # Recursos da interface
├── Program.cs             # Ponto de entrada
└── Properties/            # Configurações do projeto
```

---

## ⚠️ Avisos Importantes

### 🧠 Uso Responsável

- Este software é destinado **apenas para fins educacionais e de teste**  
- Use apenas em processos que você possui ou tem permissão para modificar  
- **Não use** para fins maliciosos ou em sistemas de terceiros sem autorização  

### 🧱 Limitações

- A injeção pode falhar em processos com proteções avançadas  
- Alguns antivírus podem detectar a injeção  
- Processos de 64 bits podem requerer DLLs compatíveis  

### 💻 Compatibilidade

- Testado em Windows 10/11  
- Funciona com processos de **32 e 64 bits**  
- Requer privilégios de administrador para alguns processos  

---

## 🐛 Solução de Problemas

### Erro: "Processo não encontrado"

- Verifique se o processo está rodando  
- Digite o nome correto (sem `.exe`)  
- Use o Gerenciador de Tarefas para verificar os nomes dos processos  

### Erro: "Falha ao abrir o processo"

- Execute o aplicativo como administrador  
- Verifique se o processo não possui proteções especiais  
- Tente com um processo mais simples primeiro (ex: `notepad`)  

### DLL não aparece na lista

- Verifique se o arquivo é realmente uma DLL válida  
- Tente adicionar novamente  
- Verifique permissões de acesso ao arquivo  

---

## 📝 Log de Alterações

### Versão 1.0

- Interface gráfica moderna com Guna.UI2  
- Sistema de gerenciamento de DLLs  
- Injeção por APC implementada  
- Prevenção de duplicatas  
- Interface responsiva e intuitiva  

---

## 🤝 Contribuição

Este projeto é para fins educacionais. Se você encontrar bugs ou quiser melhorar o código:

1. Faça um **fork** do projeto  
2. Crie uma **branch** para sua feature  
3. **Commit** suas mudanças  
4. Dê **push** para a branch  
5. Abra um **Pull Request**  

---

## 📄 Licença

Este projeto é fornecido "como está", para fins educacionais.  
**Use com responsabilidade** e apenas em sistemas que você possui ou tem permissão para modificar.

---

## 📞 Suporte

Para dúvidas ou problemas:

- Verifique a seção de **Solução de Problemas**  
- Teste com processos simples primeiro  
- Certifique-se de executar como administrador quando necessário  

---

> ⚠️ **Lembre-se:** Use este software de forma ética e responsável. Apenas para fins educacionais e em sistemas que você possui.
