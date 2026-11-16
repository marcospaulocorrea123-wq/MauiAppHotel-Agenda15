# 📅 MauiAppEvento — Sistema de Cadastro e Cálculo de Eventos (.NET MAUI)

---

## 🎯 Objetivo da Atividade

O **MauiAppEvento** foi desenvolvido como atividade prática da disciplina de **Programação Mobile / Desenvolvimento de Sistemas II (Agenda 15)**. 

O foco principal do projeto foi a **evolução arquitetural** a partir da aplicação da Agenda 14, adaptando a estrutura de formulários, modelos de dados e regras de cálculo para um sistema de gestão e cadastro de eventos, alicerçado nos conceitos fundamentais da **Programação Orientada a Objetos (POO)** e do framework **.NET MAUI**:
* **Separação em Camadas:** Organização estruturada entre regras de domínio (`Models/Evento.cs`) e apresentação visual (`Views/CadastroEventoPage.xaml` e `Views/ResumoEventoPage.xaml`).
* **Modelo de Domínio (`Evento`):** Abstração das propriedades do evento (*Nome*, *Local*, *DataInicio*, *DataTermino*, *NumeroParticipantes*, *CustoPorParticipante*) com propriedades calculadas dinâmicas (`DuracaoEmDias` e `CustoTotal`).
* **Manipulação de Datas e Períodos:** Uso das estruturas **`DateTime`** e **`TimeSpan`** para calcular a diferença exata em dias entre o início e o término do evento.
* **Comunicação e Formatação entre Telas:** Compartilhamento de dados via **`BindingContext`** durante a navegação por pilha (`NavigationPage`) e formatação visual em XAML utilizando **`StringFormat`** (para datas em `dd/MM/yyyy` e moeda em `R$`).

> 📌 **Nota sobre a Estrutura do Projeto e Estratégia de Desenvolvimento:**  
> Durante as tentativas de criar e implementar um projeto do zero para a Agenda 15 (`MauiAppEvento`), ocorreram erros recorrentes de compilação, geração de arquivos intermediários (`*.g.cs`) e resolução de namespaces. Para contornar essas falhas e garantir o pleno funcionamento da aplicação, optou-se por **reaproveitar e atualizar os arquivos da estrutura anterior que não apresentavam erros de compilação**, refatorando-os para atender 100% aos requisitos da Agenda 15.

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
MauiAppHotel/ (Adaptado para MauiAppEvento)
├── Models/
│   └── Evento.cs                 # Modelo de dados com regras de cálculo (DuracaoEmDias e CustoTotal)
│   └── Hospedagem.cs  
│   └── Suite.cs  
├── Views/
│   ├── CadastroEventoPage.xaml    # Formulário de entrada de dados do evento
│   ├── CadastroEventoPage.xaml.cs # Lógica de validação e disparo da navegação
│   ├── ResumoEventoPage.xaml      # Exibição dos dados do evento com Data Binding e StringFormat
│   └── ResumoEventoPage.xaml.cs   # Lógica da tela de resumo (PopAsync)
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
   * Ao clicar no botão **"Cadastrar Evento"**, o sistema valida se a data de término é igual ou posterior à data de início. Caso contrário, um alerta orientativo é exibido.
5. **Navegação para a Tela de Resumo (`ResumoEventoPage`):**
   * Os dados preenchidos alimentam uma instância da classe `Evento`, enviada como `BindingContext` para a tela de resumo através de `Navigation.PushAsync`.
6. **Visualização dos Resultados Formatados:**
   * A tela de resumo exibe todas as informações organizadas, com destaque para a **Duração do Evento em Dias** (calculada via `TimeSpan`) e o **Custo Total** formatado em moeda nacional (`R$`).

---

## 📱 Apresentação das Telas do App

Abaixo estão ilustrados os fluxos essenciais da aplicação:

1. **Tela de Cadastro (`CadastroEventoPage`):** Formulário completo com seletores de data e campos numéricos.
2. **Alerta de Validação de Datas:** Bloqueio de inserções com datas inconsistentes.
3. **Tela de Resumo (`ResumoEventoPage`):** Exibição dos cálculos consolidados com cartões de destaque visual.
   
 <img width="1428" height="746" alt="01" src="https://github.com/user-attachments/assets/918aec70-257e-4349-9100-4bf3331ad3fd" />

---

## ⚠️ Dificuldades Enfrentadas e Soluções Técnicas

Durante a execução da Agenda 15, diversos desafios de compilação e estruturação foram superados:

1. **Dificuldade na Criação de Projeto do Zero e Estratégia de Contorno:**
   * *Desafio:* Não foi possível criar e implementar um novo arquivo/projeto do zero para a entidade `Evento` sem disparar erros de build contínuos (`CS0103`, `CS0246`, `XLS0414`), pois o compilador perdia as referências dos componentes XAML gerados em `obj/`.
   * *Solução:* Como alternativa técnica de contorno, atualizou-se a estrutura de arquivos da aplicação pré-existente (da Agenda 14) que não apresentava erros de compilação. Os modelos (`Hospedagem.cs` → `Evento.cs`) e visões foram refatorados mantendo a estabilidade da solução.

2. **Conflito de Namespaces entre Projetos:**
   * *Desafio:* Ao reaproveitar o projeto anterior, a alteração inconsistente dos namespaces no C# desalinhou a diretiva `x:Class` no XAML.
   * *Solução:* Realinhamento estrito dos namespaces em todos os arquivos (`MauiAppHotel.Models` e `MauiAppHotel.Views`), seguido de limpeza completa das pastas `bin` e `obj`.

3. **Erros de Importação e Ambiguidade em `App.xaml.cs` (`CS0118` e `CS0246`):**
   * *Desafio:* O compilador confundia a propriedade `MainPage` com a classe `MainPage.xaml.cs` existente na raiz.
   * *Solução:* Adição das diretivas `using Microsoft.Maui.Controls;` e declaração explícita `this.MainPage = new NavigationPage(...)`.

4. **Bloqueio de Arquivos na Compilação Android (`XARDF7024`):**
   * *Desafio:* O erro `System.IO.IOException: A pasta não está vazia` bloqueava a tarefa de limpeza no SDK Android.
   * *Solução:* Finalização dos processos `adb.exe` e `java.exe` no Gerenciador de Tarefas do Windows e exclusão manual do diretório `obj`.

5. **Tratamento de Alertas e Tipos Anuláveis (`CS0618` e `CS8618`):**
   * *Desafio:* Avisos de descontinuação de `DisplayAlert` e alertas de propriedades de texto que aceitam nulo na model `Evento.cs`.
   * *Solução:* Adoção de `DisplayAlertAsync` e inicialização de propriedades de texto com `string.Empty`.

---

## 🏁 Conclusão

A implementação da **Agenda 15** consolidou a transição para aplicações mobile totalmente orientadas a regras de negócio dinâmicas. 

A combinação entre a manipulação de períodos com **`DateTime` / `TimeSpan`**, o cálculo automatizado de custos dentro da classe de modelo **`Evento`** e a passagem de parâmetros via **`BindingContext`** demonstra o poder da arquitetura desacoplada do **.NET MAUI**.
