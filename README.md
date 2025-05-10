# 🛡️ IT‑Security Messenger – ChatTool

Ein sicherer Ende‑zu‑Ende‑Messenger, entwickelt im Rahmen des IT‑Security‑Schwerpunkts an der FH Wiener Neustadt.  
Das Projekt demonstriert, wie moderne .NET‑Technologien, Clean‑Architecture‑Prinzipien und bewährte Kryptografie vereint werden können, um vertrauliche Kommunikation zu ermöglichen.

---

## 📸 Screenshots

![grün](https://github.com/user-attachments/assets/176face6-3808-4803-b134-30e4ca7a0b34)
![grau](https://github.com/user-attachments/assets/efc30e00-a0ce-4fd8-8ae5-71e956571996)

---

## 🚀 Funktions‑Highlights

| Kategorie                   | Details                                                                                                                                                                                            |
| --------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **User‑Management**         | ASP.NET Core Identity (PBKDF2‑Passwort‑Hashes, Salt, Lockout, E‑Mail‑Bestätigung)                                                                                                                  |
| **E2E‑Verschlüsselung**     | RSA‑2048 + OAEP‑SHA256 - Public Key wird **einmalig** bei der Registrierung an den Server übertragen - Private Key wird **nur lokal** verschlüsselt gespeichert (`private.key.secure`)             |
| **Transport & Speicherung** | Komplett über HTTPS - Entity Framework Core verhindert SQL‑Injection - Server speichert ausschließlich Ciphertext                                                                                  |
| **UI**                      | Modernes WPF‑Frontend (.NET 9, MVVM, dunkles Theme)                                                                                                                                                |
| **Nachrichten**             | Text‑Nachrichten als Binär‑Payload; Architektur für spätere Anhänge vorbereitet                                                                                                                    |

---

## 🏗️ Projektstruktur

```text
ChatTool.Backend.sln
├─ ChatTool.Backend.Tests           ← ????
├─ ChatTool.Backend.WebApi          ← ASP.NET Core WebAPI (Startup & Auth)
├─ ChatTool.Backend.Persistence     ← EF‑Core‑DbContext & Migrations
├─ ChatTool.Backend.Infrastructure  ← ????
├─ ChatTool.Backend.Application  ← ????
└─ ChatTool.Backend.Domain  ← ????

ChatTool.Frontend.sln
├─ ChatTool.Frontend.Wpf            ← WPF‑Client (Views, ViewModels, Models)
├─ ChatTool.Frontend.Maui           ← ????
├─ ChatTool.Frontend.ConsoleUI      ← ????
└─ ChatTool.Shared                  ← DTOs, Enums (MessageType …)
```

---

## 🔐 Sicherheitskonzept

1. **Registrierung**
   • Client erzeugt ein RSA‑Schlüsselpaar (2048 Bit)
   • `PublicKeyBase64` → Server / Datenbank
   • `PrivateKey` → mit Windows DPAPI (`ProtectedData`) verschlüsselt und in `%AppData%/ChatTool/private.key.secure` abgelegt

2. **Nachricht senden**
   • Sender lädt den Public Key des Empfängers
   • Nachricht wird **clientseitig** mit OAEP‑SHA256 verschlüsselt
   • Ciphertext wird via HTTPS an `/api/Message/SendMessage` übertragen

3. **Nachricht empfangen**
   • Client entschlüsselt `private.key.secure` → Private Key im RAM
   • Ciphertext wird mit Private Key entschlüsselt, Klartext bleibt nur im Arbeitsspeicher

4. **Server**
   • kennt niemals Private Keys oder Klartext
   • kümmert sich ausschließlich um Authentifizierung, Routing & Persistenz von Ciphertext

---

## ⚙️ Installation (Developer Setup)

```bash
# 1) Repository klonen
git clone https://github.com/Katharon/ChatTool.git
cd ChatTool

# 2) Datenbank anlegen & Migrations anwenden
 dotnet ef database update \
   --startup-project ./ChatTool.Backend.WebApi \
   --project ./ChatTool.Backend.Persistence

# 3) Backend starten
 dotnet run --project ./ChatTool.Backend.WebApi

# 4) Frontend (WPF) starten
 dotnet run --project ./ChatTool.Frontend.Wpf
```

> **Voraussetzungen:** .NET 9 SDK, SQL Server Express 16+, Windows 10/11.

---

## 🖥️ Verwendung

1. **Registrieren** – Benutzername / E‑Mail / Passwort eingeben → RSA‑Keypair wird erstellt.
2. **Login** – `private.key.secure` wird entschlüsselt und in RAM gehalten.
3. **Chatten** – Nachrichten werden automatisch verschlüsselt übertragen und nur vom Empfänger gelesen.

---

## 🧪 Tests & Werkzeuge

* Postman‑Sammlung für API‑Smoke‑Tests (`docs/Postman/ChatTool.postman_collection.json`) // Bitte ändere das zu Scalar (Swagger Nachfahre)
* SQL Server Management Studio zum Inspizieren der Datenbankeinträge
* Geplant: xUnit‑Tests für Kryptofunktionen & Integration.

---

## ✨ Roadmap

* Ausschließlich im RAM gehaltenen Private Key - ohne lokaler Speicherung (ähnlich wie Signal und Threema).

---

## 📚 Quellen & Danksagung

* Microsoft Docs – ASP.NET Core Identity, EF Core
* OWASP Cheat Sheet Series – Password Storage, TLS Best Practices
* RFC 8018 – PBKDF2
* Signal Protocol Whitepaper – Inspiration zu E2EE‑Best‑Practices

---

© 2025 **Lukas Stumpfel** – FH‑Projekt *IT‑Security*.
Lizenz: MIT – siehe [`LICENSE`](./LICENSE).
Pull‑Requests und Issues sind willkommen!
