   M S B A M L   `   `   `  ����J  FWPFRegistracija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WPFRegistracija.FormeWPFRegistracija.Forme  5   	   '    !WPFRegistracija.Forme.FrmKomentar   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:WPFRegistracija.Forme     5   	     � Title$  	Komentari��5   	   $	��450��6   $	��800��6(   .��5	      � .+�5
   
   �� $��Sadrzaj��6   $
��Left=�6"   $��	36,27,0,0q�6=   $	��Top=�6P   �� 5   
   -   5         ��Name$ komentarUnos��5      $
��Left=�6(   $��
103,27,0,0q�6C    �� TextWrapping$
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��189��6�   $��35��6�   �� 5   
   $��Sudija��6   $
��Left=�6!   $��
326,27,0,0q�6<   $	��Top=�6P   �� 5   
   -   5         ��Name$ odabirSudije��5      $
��Left=�6)   $��
373,29,0,0q�6D   $	��Top=�6X   $	��120��6p    �� DisplayMemberPath$	 Ime��6|    �� SelectedValuePath$ Id��6�   �� 5   
   $��Ocena��6   $
��Left=�6    $��
525,29,0,0q�6;   $	��Top=�6O   �� 5   
   -   5        $ odabirOcene��5      $
��Left=�6(   $��
574,31,0,0q�6C   $	��Top=�6W   $	��120��6o   $ Id��6{   $ Id��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ komentariPrikaz��5         AutoGenerateColumns$ False��6,   $��36,134,225,44q�6H      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Id+  5      $	 Sadrzaj��6%   
 66   �� *	Sadrzaj+  5      $	 IdSudije��6%   
 67   �� *
IdSudije+  5      $	 IdOcene��6%   
 66   �� *	IdOcene+5      �� 5   
   -   5         ��Name$ unesiBtn��5      $��Unesi��6#   $
��Left=�63   $��	36,89,0,0q�6N   $	��Top=�6a   6y   �� 5   
   -   5        $ 	izmeniBtn��5      $��Izmeni��6$   $
��Left=�65   $��
103,89,0,0q�6P   $	��Top=�6d   6|   �� 5   
   -   5        $ 	obrisiBtn��5      $��Obrisi��6$   $
��Left=�65   $��
178,89,0,0q�6P   $	��Top=�6d   6|   5      5      