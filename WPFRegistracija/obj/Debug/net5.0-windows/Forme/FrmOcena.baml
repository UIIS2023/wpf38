   M S B A M L   `   `   `  ����J  FWPFRegistracija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WPFRegistracija.FormeWPFRegistracija.Forme  5   	   $    WPFRegistracija.Forme.FrmOcena   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:WPFRegistracija.Forme     5   	     � Title$  FrmOcena��5   	   $	��450��6   $	��800��6'   .��5	      � .+�5
   
   �� $��Ocena��6   $
��Left=�6    $��	31,37,0,0q�6;   $	��Top=�6N   �� 5   
   -   5         ��Name$ 	ocenaUnos��5      $
��Left=�6%   $��	93,45,0,0q�6@    �� TextWrapping$
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��120��6�   �� 5   
   $	��Pas��6   $
��Left=�6   $��
262,41,0,0q�69   $	��Top=�6M   �� 5   
   -   5         ��Name$ 	pasOdabir��5      $
��Left=�6&   $��
305,45,0,0q�6A   $	��Top=�6U   $	��120��6m    �� DisplayMemberPath$	 Ime��6y    �� SelectedValuePath$ Id��6�   �� 5   
   $��Sudija��6   $
��Left=�6!   $��
488,45,0,0q�6<   $	��Top=�6P   �� 5   
   -   5        $ sudijaOdabir��5      $
��Left=�6)   $��
535,50,0,0q�6D   $	��Top=�6X   $	��120��6p   $	 Ime��6|   $ Id��6�   �� 5   
   -   5         ��Name$ unosBtn��5      $��Unesi��6#   $
��Left=�63   $��
33,106,0,0q�6N   $	��Top=�6b   6z   �� 5   
   -   5        $ 	izmeniBtn��5      $��Izmeni��6%   $
��Left=�66   $��107,106,0,0q�6Q   $	��Top=�6f   6~   �� 5   
   -   5        $ 	obrisiBtn��5      $��Obrisi��6%   $
��Left=�66   $��188,106,0,0q�6Q   $	��Top=�6f   6~   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ocenePrikaz��5         AutoGenerateColumns$ False��6(   $��31,151,259,67q�6D   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $
 Ocena��6%    64   �� *Ocena+  5      $
 IdPsa��6%    64   �� *IdPsa+  5      $
 IdSudije��6%    67   �� *
IdSudije+5      5      5      