   M S B A M L   `   `   `  ����H  DLMP.WPF.Admin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:LMP.WPF.Admin.CommandssLMP.WPF.Admin.Commandss  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	       LMP.WPF.Admin.ShellView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   s oTelerik.Windows.Controls.RichTextBoxUI, Version=2015.2.623.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2015.2.623.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Documents.Core, Version=2015.2.623.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q	 mTelerik.Windows.Controls.ImageEditor, Version=2015.2.623.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k
 gTelerik.Windows.Controls.Input, Version=2015.2.623.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2015.2.623.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2015.2.623.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Documents.FormatProviders.Rtf, Version=2015.2.623.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2015.2.623.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Documents, Version=2015.2.623.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7{ wTelerik.Windows.Documents.FormatProviders.Html, Version=2015.2.623.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7{ wTelerik.Windows.Documents.FormatProviders.Xaml, Version=2015.2.623.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Utelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
        5   	   Glocal%clr-namespace:LMP.WPF.Admin.Commandss    	 
        5   	   niPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity    	 
        5   	   ^ ZCaliburn.Micro.Platform, Version=2.0.2.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5   	     � Title$  	ShellView��5   	   $	��400��6   $	��300��6(   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��140 �6   6+   �� 5      6    � ColumnDefinitions 5   
   .+�5   
   C  =Telerik.Windows.Controls.RichTextBoxUI.RadRichTextBoxRibbonUI  -   5          Name$ radRichTextBoxRibbonUI��5   )   $
��Left=�6I   $	��Top=�6e    � DataContext$ 
SongEditor��6}   .@�5      +  %Telerik.Windows.Controls.RadRibbonTab  $��Inicio��6#   (  "Telerik.Windows.Controls.ScreenTip   Title$ Inicios��63      Description$ Inicio��6U   .@�5      -  'Telerik.Windows.Controls.RadRibbonGroup  $��Administración de Letras��6)   .@�5      .  (Telerik.Windows.Controls.RadRibbonButton  -   5          Name$ LoadSongElement��5   .   $��Abrir Letra��6G   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5      	   	EventName$	 Click��6-   .  (System.Windows.Interactivity.TriggerBase
   Actions.
 5   "   "	  Caliburn.Micro.ActionMessage	   	  
MethodName$ 
LoadLyrics��64    	  
Parameters. 5   &   
  Caliburn.Micro.Parameter
   
  Value$ 
$eventArgs��64   
  5   &    64   ��  �� ElementName$ 
SongEditor��5   #   5      5!        5#      -   5        $ SaveSongElement��5#   .   $��Guardar��6G    5$        5%      $	 Click��6-   .
 5&   "   	  $ 
SaveLyrics��64   . 5'   &   
  $ 
$eventArgs��64   
  5(   &    64   �� $ 
SongEditor��5)   #   5*      5,      5-      5.        50      $��Letra��6#   $ Lyrics��62   $ Operaciones sobre letra��6S   .@�51        $��Edicion de Letras��6)   .@�52        -   5        $ AddVerso��52   .   $��Verso��6@    53        54      $	 Click��6-   .
 55   "   	  $ AddVerso��64   . 56   &   
  $ 
$eventArgs��64   
  57   &    64   �� $ 
SongEditor��58   #   59      5;        5=      -   5        $ AddCoro��5=   .   $
��Coro��6?    5>        5?      $	 Click��6-   .
 5@   "   	  $ AddCoro��64   . 5A   &   
  $ 
$eventArgs��64   
  5B   &    64   �� $ 
SongEditor��5C   #   5D      5F        5H      -   5        $ DeleteSongElement��5H   .   $��Delete��6I    5I        5J      $	 Click��6-   .
 5K   "   	  $ DeleteMusicFragment��64   . 5L   &   
  $ 
$eventArgs��64   
  5M   &    64   �� $ 
SongEditor��5N   #   5O      5Q      5T      5U      5X      -  'Telerik.Windows.Controls.RadRichTextBox  5Z   
   -   5          Name$ 
SongEditor��5Z   !   $��1��65   5      5�      