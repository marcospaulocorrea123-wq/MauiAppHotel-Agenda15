# 📅 MauiAppEvento — Sistema de Cadastro e Cálculo de Eventos (.NET MAUI)

---

## 🎯 Objetivo da Atividade

O **MauiAppEvento** foi desenvolvido como atividade prática da disciplina de **Programação Mobile / Desenvolvimento de Sistemas II (Agenda 15)**. 

O foco principal do projeto foi a **evolução arquitetural** a partir da aplicação da Agenda 14, adaptando a estrutura de formulários, modelos de dados e regras de cálculo para um sistema de gestão e cadastro de eventos, alicerçado nos conceitos fundamentais da **Programação Orientada a Objetos (POO)** e do framework **.NET MAUI**:
* **Separação em Camadas:** Organização estruturada entre regras de domínio e apresentação visual.
* **Modelo de Domínio (`Evento`):** Abstração das propriedades do evento (*Nome*, *Local*, *DataInicio*, *DataTermino*, *NumeroParticipantes*, *CustoPorParticipante*) com propriedades calculadas dinâmicas (`DuracaoEmDias` e `CustoTotal`).
* **Manipulação de Datas e Períodos:** Uso das estruturas **`DateTime`** e **`TimeSpan`** para calcular a diferença exata em dias entre o início e o término do evento.
* **Comunicação e Formatação entre Telas:** Compartilhamento de dados via **`BindingContext`** durante a navegação por pilha (`NavigationPage`) e formatação visual em XAML utilizando **`StringFormat`** (para datas em `dd/MM/yyyy` e moeda em `R$`).

> 📌 **Nota Importante sobre a Estrutura do Projeto:**  
> Durante o desenvolvimento, não foi possível implementar e utilizar novos arquivos especificamente nomeados como `Models/Evento.cs` e visões de apresentação visual `Views/CadastroEventoPage.xaml` e `Views/ResumoEventoPage.xaml`. A criação desses novos arquivos provocou erros de compilação persistentes no ambiente. Para contornar esses erros e garantir o pleno funcionamento da aplicação, **as novas funções da Agenda 15 foram implementadas adaptando diretamente os códigos dentro das páginas já existentes do projeto anterior**.

---

## 🤖 Uso da Inteligência Artificial no Desenvolvimento

Neste projeto, a **Inteligência Artificial (IA)** foi adotada de forma estratégica como **ferramenta de apoio ao desenvolvedor (Pair Programming / Copiloto)**, contribuindo diretamente nas seguintes etapas:

* **Diagnóstico e Resolução de Erros de Build:** Análise detalhada de logs de compilação complexos (erros `CS0103`, `CS0246`, `XLS0414` e exceção de IO `XARDF7024`), identificando rapidamente divergências entre namespaces C# e diretivas `x:Class` no XAML.
* **Modernização e Refatoração de Código:** Apoio na transição de chamadas obsoletas (`DisplayAlert` para `DisplayAlertAsync`) e tratamento de avisos de referência nula (`CS8618`).
* **Resolução de Conflitos de Plataforma Android/Windows:** Diagnóstico de travamento de pastas temporárias em `obj/Debug/net10.0-android/` por processos como `adb.exe` e `java.exe`.
* **Padronização Arquitetural e Documentação:** Auxílio no mapeamento da transição entre Agenda 14 e Agenda 15, bem como na estruturação da documentação técnica para o repositório no GitHub.

---

## 🛠️ Tecnologias e Ferramentas 

- **Linguagem:** C# (.NET MAUI)
- **Framework:** .NET MAUI / .NET 10 / .NET 8
- **IDE:** Visual Studio Community
- **Controle de Versão:** Git / GitHub

```text
MauiAppHotel/ (Projeto adaptado contendo a lógica e funções da Agenda 15)
├── Models/
│   └── Hospedagem.cs (contém a lógica e propriedades do modelo Evento)
├── Views/
│   ├── ContratacaoHospedagem.xaml (contém o formulário de Cadastro de Evento)
│   ├── ContratacaoHospedagem.xaml.cs
│   ├── HospedagemContratada.xaml (contém a tela de Resumo do Evento)
│   └── HospedagemContratada.xaml.cs
├── App.xaml.cs                    # Configuração da NavigationPage inicial
└── MauiProgram.cs                 # Builder da aplicação .NET MAUI
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
<img width="1440" height="744" alt="01" src="https://github.com/user-attachments/assets/9b48cc2d-9775-4492-9128-88003ab3c8a0" />

---

## ⚠️ Dificuldades Enfrentadas e Soluções Técnicas

Durante a execução da Agenda 15, diversos desafios de compilação e estruturação foram superados:

1. **Impossibilidade de Implementação de Novos Nomes de Páginas (`Models/Evento.cs` e `Views/CadastroEventoPage.xaml` / `ResumoEventoPage.xaml`):**
   * *Desafio:* Não foi possível criar e implementar novas páginas utilizando os nomes indicados na atividade (`Models/Evento.cs`, `Views/CadastroEventoPage.xaml` e `Views/ResumoEventoPage.xaml`), pois a criação desses arquivos provocava erros críticos de compilação (`CS0103`, `CS0246`, `XLS0414`). O compilador do .NET MAUI perdia o vínculo com a diretiva `x:Class` e com a geração do `InitializeComponent` em `obj/`.
   * *Solução:* Para contornar as falhas de compilação e garantir uma aplicação estável e funcional, **as novas funções da Agenda 15 foram implementadas adaptando diretamente o código das páginas anteriores que já compilavam perfeitamente**.

2. **Conflito de Namespaces entre Projetos:**
   * *Desafio:* Ao refatorar o código, alterações de namespaces geraram desalinhamento com a diretiva `x:Class` do XAML.
   * *Solução:* Realinhamento estrito dos namespaces em todos os arquivos C# e XAML, seguido de limpeza das pastas `bin` e `obj`.

3. **Erros de Importação e Ambiguidade em `App.xaml.cs` (`CS0118` e `CS0246`):**
   * *Desafio:* O compilador confundia a propriedade `MainPage` com a classe `MainPage.xaml.cs` existente na raiz.
   * *Solução:* Adição das diretivas `using Microsoft.Maui.Controls;` e declaração explícita `this.MainPage = new NavigationPage(...)`.

4. **Bloqueio de Arquivos na Compilação Android (`XARDF7024`):**
   * *Desafio:* O erro `System.IO.IOException: A pasta não está vazia` bloqueava a tarefa de limpeza no SDK Android.
   * *Solução:* Finalização dos processos `adb.exe` e `java.exe` no Gerenciador de Tarefas do Windows e exclusão manual do diretório `obj`.

5. **Tratamento de Alertas e Tipos Anuláveis (`CS0618` e `CS8618`):**
   * *Desafio:* Avisos de descontinuação de `DisplayAlert` e alertas de propriedades de texto que aceitam nulo na model.
   * *Solução:* Adoção de `DisplayAlertAsync` e inicialização de propriedades de texto com `string.Empty`.

---

## 🏁 Conclusão

A implementação da **Agenda 15** consolidou a transição para aplicações mobile totalmente orientadas a regras de negócio dinâmicas. 

A combinação entre a manipulação de períodos com **`DateTime` / `TimeSpan`**, o cálculo automatizado de custos dentro do modelo do evento e a passagem de parâmetros via **`BindingContext`** demonstra o poder da arquitetura desacoplada do **.NET MAUI**, superando os desafios de compilação com soluções práticas de contorno.

