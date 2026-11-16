# 📅 MauiAppEvento — Sistema de Cadastro e Cálculo de Eventos (.NET MAUI)

---

## 🎯 Objetivo da Atividade

O **MauiAppEvento** foi desenvolvido como atividade prática da disciplina de **Programação Mobile / Desenvolvimento de Sistemas II (Agenda 15)**. 

O foco principal do projeto foi a **evolução arquitetural** a partir da aplicação da Agenda 14, adaptando a estrutura de formulários, modelos de dados e regras de cálculo para um sistema de gestão e cadastro de eventos, alicerçado nos conceitos fundamentais da **Programação Orientada a Objetos (POO)** e do framework **.NET MAUI**:
* **Separação em Camadas:** Organização estruturada entre regras de domínio e apresentação visual.
* **Modelo de Domínio (`Evento`):** Abstração das propriedades do evento (*Nome*, *Local*, *DataInicio*, *DataTermino*, *NumeroParticipantes*, *CustoPorParticipante*) com propriedades calculadas dinâmicas (`DuracaoEmDias` e `CustoTotal`).
* **Manipulação de Datas e Períodos:** Uso das estruturas **`DateTime`** e **`TimeSpan`** para calcular a diferença exata em dias entre o início e o término do evento.
* **Comunicação e Formatação entre Telas:** Compartilhamento de dados via **`BindingContext`** durante a navegação por pilha (`NavigationPage`) e formatação visual em XAML utilizando **`StringFormat`** (para datas em `dd/MM/yyyy` e moeda em `R$`).

> 📌 **Nota Importante sobre a Estrutura do Projeto :**  
> Conforme comprovado pela análise da estrutura física de diretórios, a tentativa inicial de criar novos arquivos com nomes específicos (`Models/Evento.cs`, `Views/CadastroEventoPage.xaml` e `Views/ResumoEventoPage.xaml`) gerou falhas de compilação contínuas e desalinhamento de arquivos intermediários (`*.classe.cs`). Esse processo de depuração resultou no catalogamento de **mais de 100 erros de compilação e build conforme anexo no repositorio na planilha `LISTA DE ERROS.xlsx`**, consumindo **mais de 60% do tempo total do projeto**. Para contornar essas falhas e garantir a entrega de uma aplicação 100% estável e funcional, **a lógica e as funções da Agenda 15 foram implementadas adaptando diretamente os códigos dentro dos arquivos físicos já compilados do projeto anterior** (`MauiAppHotel.csproj`, `Hospedagem.cs`, `ContratacaoHospedagem.xaml` e `HospedagemContratada.xaml`).

---

## 🛠️ Tecnologias e Ferramentas 

- **Linguagem:** C# (.NET MAUI)
- **Framework:** .NET MAUI / .NET 10 / .NET 8 (Targets: Windows, Android, iOS, MacCatalyst)
- **IDE:** Visual Studio Community
- **Documentação de Erros:** Planilha `LISTA DE ERROS.xlsx` (mapeamento de mais de 100 erros de compilação)
- **Mapeamento de Estrutura:** Arquivo `ARVOREv3.txt` (estrutura física final da solução `AGENDA15C\MauiAppHotel`)
- **Controle de Versão:** Git / GitHub

```text
C:\Dev_Projetos\AGENDA15C\MauiAppHotel/ (Estrutura física confirmada em ARVOREv3.txt)
├── MauiAppHotel.csproj            # Projeto .NET MAUI principal
├── App.xaml / App.xaml.cs          # Inicialização da NavigationPage
├── AppShell.xaml / AppShell.xaml.cs
├── MauiProgram.cs                 # Builder da aplicação
├── Models/
│   ├── Hospedagem.cs              # Contém a lógica de dados do Evento (Nome, Datas, Participantes, CustoTotal)
│   └── Suite.cs                   # Estrutura auxiliar de suporte
├── Views/
│   ├── ContratacaoHospedagem.xaml   # Interface XAML do Cadastro de Evento
│   ├── ContratacaoHospedagem.xaml.cs# Code-behind com validações e DateTime/TimeSpan
│   ├── HospedagemContratada.xaml    # Interface XAML da Tela de Resumo do Evento
│   ├── HospedagemContratada.xaml.cs # Code-behind com BindingContext do evento
│   ├── SobrePage.xaml              # Tela informativa adicional
│   └── SobrePage.xaml.cs
└── bin / obj                      # Cache e artefatos de compilação multi-plataforma
```

---

## 🚀 Como Utilizar o Aplicativo

1. **Preenchimento dos Dados Básicos:**
   * Informe o **Nome do Evento** (ex: *Workshop de .NET MAUI*) e o **Local do Evento** (ex: *Centro de Convenções*).
2. **Definição das Datas (`DatePicker`):**
   * Selecione a **Data de Início** e a **Data de Término**.
3. **Informações Financeiras e de Público:**
   * Digite o **Número de Participantes** e o **Custo por Participante (R$)**.
4. **Validações de Regras de Negócio:**
   * Ao clicar no botão de cadastro, o sistema valida se a data de término é igual ou posterior à data de início. Caso contrário, um alerta orientativo é exibido.
5. **Navegação para a Tela de Resumo:**
   * Os dados preenchidos alimentam o modelo do evento, enviado como `BindingContext` para a tela de resumo através de `Navigation.PushAsync`.
6. **Visualização dos Resultados Formatados:**
   * A tela de resumo exibe todas as informações organizadas, com destaque para a **Duração do Evento em Dias** (calculada via `TimeSpan`) e o **Custo Total** formatado em moeda nacional (`R$`).

---

## 📱 Apresentação das Telas do App

Abaixo estão ilustrados os fluxos essenciais da aplicação:

1. **Tela de Cadastro:** Formulário completo com seletores de data e campos numéricos.
2. **Alerta de Validação de Datas:** Bloqueio de inserções com datas inconsistentes.
3. **Tela de Resumo:** Exibição dos cálculos consolidados com cartões de destaque visual.
   
<img width="1440" height="744" alt="01" src="https://github.com/user-attachments/assets/4d6eeedd-8588-45a8-ac80-cbfcbf066115" />

---

## ⚠️ Dificuldades Enfrentadas e Soluções Técnicas

Durante a execução da Agenda 15, diversos desafios de compilação e estruturação foram superados:

1. **Conflito de Namespaces entre Projetos (`CS0103` e `XLS0414`):**
   * *Desafio:* Ao reaproveitar a estrutura do projeto anterior (`MauiAppHotel`), a alteração de nomes no C# causou a perda de ligação com a diretiva `x:Class` no XAML, impedindo a criação dos arquivos parciais `*.classe.cs` e gerando erros de controles "não encontrados".
   * *Solução:* Realinhamento estrito dos namespaces (`MauiAppHotel` ou `MauiAppEvento`) entre os arquivos XAML e `.xaml.cs`, seguido de limpeza das pastas `bin` e `obj`.

2. **Erros de Importação e Ambiguidade em `App.xaml.cs` (`CS0118` e `CS0246`):**
   * *Desafio:* O compilador confundia a propriedade `MainPage` com a classe `MainPage.xaml.cs` existente na raiz.
   * *Solução:* Adição das diretivas `using Microsoft.Maui.Controls;` e declaração explícita `this.MainPage = new NavigationPage(...)`.

3. **Bloqueio de Arquivos na Compilação Android (`XARDF7024`):**
   * *Desafio:* O erro `System.IO.IOException: A pasta não está vazia` bloqueava a tarefa de limpeza no SDK Android.
   * *Solução:* Finalização dos processos `adb.exe` e `java.exe` no Gerenciador de Tarefas do Windows e exclusão manual do diretório `obj`.

4. **Tratamento de Alertas e Tipos Anuláveis (`CS0618` e `CS8618`):**
   * *Desafio:* Avisos de descontinuação de `DisplayAlert` e alertas de propriedades de texto que aceitam nulo na model `Evento.cs`.
   * *Solução:* Adoção de `DisplayAlertAsync` e inicialização de propriedades de texto com `string.Empty`.

5. **Mapeamento de Mais de 100 Erros e Tempo de Resolução (`LISTA DE ERROS.xlsx`):**
   * *Desafio:* A transição e compilação do projeto em ambiente multi-alvo (`net10.0-android`, `net10.0-windows`, `net10.0-ios`, `net10.0-maccatalyst`, visíveis em `bin/Debug/` da `ARVOREv3.txt`) geraram mais de 100 mensagens de erro e avisos, registradas na planilha **`LISTA DE ERROS.xlsx`**. Essa investigação consumiu **mais de 60% do tempo total do projeto**.
   * *Solução:* Isolamento e resolução dos erros críticos de namespace, permitindo a execução limpa da aplicação nas plataformas-alvo.

6. **Conflito e Sincronização de Namespaces (`CS0103` / `XLS0414`):**
   * *Desafio:* A mistura entre declarações `MauiAppEvento` e o assembly registrado `MauiAppHotel` impedia a geração das classes parcial `*.classe.cs`.
   * *Solução:* Uniformização de namespaces no C# e no atributo `x:Class` do XAML.

---

## 🏁 Conclusão

A implementação da **Agenda 15** consolidou a transição para aplicações mobile totalmente orientadas a regras de negócio dinâmicas. 

A combinação entre a manipulação de períodos com **`DateTime` / `TimeSpan`**, o cálculo automatizado de custos dentro da classe de modelo **`Evento`** e a passagem de parâmetros via **`BindingContext`** demonstra o poder da arquitetura desacoplada do **.NET MAUI**.
