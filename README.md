# ProxyON


**ProxyON** é un pequeno proxecto personal que serve para activar e desactivar rápidamente unha configuración personalizada para conectarse a un servidor PROXY. O aplicativo baséase [neste artigo][base] para crear un BAT coa mesma funcionalidade.

---

## DESCRICIÓN DA INTERFACE

### Formulario principal

![frm_principal_off]

#### Cinta de botóns (parte superior)

* Crear Perfil
* Editar Perfil
* Copiar Perfil
* Borrar Perfil
* Cambiar directorio de almacén de Perfiles
* Configuración de Inicio

#### Corpo central

* ComboBox para selecionar o Perfil de conexión ao servidor PROXY
* CheckBox para selecionar o Perfil por defecto que se selecionará ao iniciar o programa

#### Botón de acción

* Botón para Activar ou desactivar a configuración actual

### Área de notificación de Windows

Hai unha icona en todo momento que sinala o estado do aplicativo cambiando de cor e mostrando un globo de notificiación ao pasar o rató por enriba segundo estea:

#### Activado:
 
![notify_ico_on]

![ico_popup_on]

#### Descativado:
 
![notify_ico_off]

![ico_popup_off]

#### Menú contextual

Se se fai clic dereito sobre a icona do Área de notificación de Windows mostrase o seguiente menú:

![ico_popup_menu]

### NOTA IMPORTANTE

Ao minimizar o formulario principal só se mostrará a icona do Área de notificación de Windows, para poder ver de novo a xanela terase que selecionar a opción correspondente no menú contextual de dita icona.

---

## EMPREGO

O funcionamento é moi sinxelo; ao abrir o programa aparece un formulario no que podemos escoller un Perfil coa configuración da conexión o noso PROXY e prememos o botón de acción:

#### Activar PROXY

![frm_principal_off]

#### Desactivar PROXY

![frm_principal_on]

Outro xeito de traballar é minimizar o formulario e facer dobre clic na icona do **Área de notificación** para cambiar o estado da configuración do PROXY de **Activado** a **Desactivado** e viceversa.

---

## XESTIÓN DE PERFILES

O programa garda a información dos Perfiles mediante ficheiros XML separados, un por perfil (máis adiante indicarese a estrutura do ficheiro), pero estes ficheiros podense xerar dende **ProxyON** premendo no lugar oportuno sobre a cinta de botóns e introducir a configuración do servidor PROXY. Para gardar os cambios premeremos no botón "GARDAR DATOS":

Dispoñemos de 5 operacións para poder xestionar os Perfiles almacenados polo programa: 3 operacións para salvar a configuración, 1 para borrala e outra máis para indicarlle ao programa onde debe buscar e gardar os Perfiles almacenados.

### Crear un Perfil novo

Ábrese o formulario de configuración baleiro:

![perfil_novo]

### Editar un Perfil existente

Ábrese o formulario de configuración cos datos do servidor selecionado pero coa edición do nome desactivada:

![perfil_editar]

### Copiar un Perfil

Ábrese o formulario de configuración cos datos do servidor selecionado

![perfil_copiar]

Se se intenta gardar unha configuración co mesmo nome que un perfil existente saltará un erro:

![perfil_copiar_erro]

### Borrar un Perfil

Ao premer sobre o botón de borrado salirá unha mensaxe pedindo a confirmación da acción:

![perfil_borrar]

### Almacén de Perfiles

Poderemos indicarlle ao programa onde queremos buscar e gardar os nosos perfiles:

![perfil_cambio_dir]

---

## ESTRUTURA DO FICHEIRO DE PERFIL

``` xml
<?xml version="1.0" encoding="utf-8"?>
<Perfil xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <nome>Por defecto</nome>
    <servidor>127.0.0.1</servidor>
    <porto>80</porto>
    <excepcions>*.es;</excepcions>
    <direccionsLocais>true</direccionsLocais>
</Perfil>
```

![perfil_copiar]

---

## OPCIÓNS DE INICIO

![frm_principal_opcions]

Podemos xestionar como queremos que se inicie a aplicación entre 2 posibilidades:
1. Mostrando o formulario principal (opción por defecto)
2. Mostrando só a icona no Área de notificación de Windows

Tamén podemos selecionar se queremos que el programa se inicie con Windows:

![iniciar_win_escoller]

Se non se iniciou **ProxyON** como administrador e escolleuse a opción para que se inicie para **Tódolos usuarios** saliranos esta mensaxe indicando que se debe reiniciar o programa con permisos elevados para realizar a operación pero non fará ningún cambio, teremos que volver a escoller esta opción para que se aplique o cambio no rexistro de Windows:

![iniciar_win_permisos]

**NOTA: se se cambia de ubicación o executable haberá que volver a executar a opción 2 veces máis: a primeira para que borre a configuración anterior e a segunda para activala de novo.**

---

## COMO O FAI

### Activar

1. Ábrese a chave do rexistro de Windows **"HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings"**
2. Engádense (ou actualizanse __*__) as seguintes entradas:
   * ProxyEnable: establece o seu valor a 1 para activar a conexión vía PROXY
   * ProxyServer: garda a IP e o porto do servidor PROXY
   * ProxyOverride: garda as excepcións para as cales non se empregará o servidor PROXY
  
__* Sobrescríbese a configuración actual de Windows e polo tanto perdese__

### Desactivar

1. Ábrese a chave do rexistro de Windows **"HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings"**
2. Bórranse as seguintes entradas __**__:
    * ProxyServer
    * ProxyOverride
3. Engadese (ou actualizase) a entrada:
    * ProxyEnable: establece o seu valor a 0 para desactivar a conexión vía PROXY
  
__** Bórrase a configuración do PROXY, polo que a configuración de Windows quedaría baleira__

### Iniciar con Windows

1. Ábrese a chave do rexistro de Windows:
    * Para o usuario actual: **"HKCU\Software\Microsoft\Windows\CurrentVersion\Run"**
    * Para tódolos usuarios: **"HKLM\Software\Microsoft\Windows\CurrentVersion\Run"**

2. Engadese __*__ (ou actualizase __**__) a seguinte entrada:
    * **ProxyON**: coa ruta absoluta do executable do aplicativo
  
__* Se a entrada xa está (en calquiera das 2 ramas do rexistro) bórrase para evitar que o programa se inicie de novo con Windows__

__** Sobrescríbese a configuración actual de Windows__

[//]: # (Listado dos links empregados)

   <!-- Licencia -->

   [LICENSE.md]: <LICENSE.md>

   <!-- Guía de contribución -->

   [CONTRIBUTING]: <CONTRIBUTING.md>
   [NovaIncidencia]: <CONTRIBUTING.md#notificando-unha-incidencia>

   <!-- Enlaces a terceiros -->

   [base]: <https://cybermcp.blogspot.com/2014/02/bat-para-activar-y-desactivar-proxy-en.html>

   <!-- Enlaces imaxes -->

   [frm_principal_off]: <doc/img/frm_principal_off.png>
   [frm_principal_on]: <doc/img/frm_principal_on.png>
   [frm_principal_opcions]: <doc/img/frm_principal_opcions.png>

   [notify_ico_on]: <doc/img/notify_ico_on.png>
   [notify_ico_off]: <doc/img/notify_ico_off.png>

   [ico_popup_menu]: <doc/img/ico_popup_menu.png>
   [ico_popup_on]: <doc/img/ico_popup_on.png>
   [ico_popup_off]: <doc/img/ico_popup_off.png>
   
   [iniciar_win_escoller]: <doc/img/iniciar_win_escoller.png>
   [iniciar_win_permisos]: <doc/img/iniciar_win_permisos.png>

   [perfil_novo]: <doc/img/perfil_novo.png>
   [perfil_editar]: <doc/img/perfil_editar.png>
   [perfil_copiar]: <doc/img/perfil_copiar.png>
   [perfil_copiar_erro]: <doc/img/perfil_copiar_erro.png>
   [perfil_borrar]: <doc/img/perfil_borrar.png>
   [perfil_cambio_dir]: <doc/img/perfil_cambio_dir.png>
   
