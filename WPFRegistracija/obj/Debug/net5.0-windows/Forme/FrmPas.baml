   M S B A M L   `   `   `  ����J  FWPFRegistracija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WPFRegistracija.FormeWPFRegistracija.Forme  5   	   "    WPFRegistracija.Forme.FrmPas   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:WPFRegistracija.Forme     5   	     � Title$	  Pas��5   	   $	��710��6   $	��855��6"   .��5	      � $��0,0,210,168q�6   .+�5
   
   �� $	��Ime��6   $
��Left=�6   $��	33,36,0,0q�69   $	��Top=�6L   �� 5   
   -   5         ��Name$ imeUnos��5      $
��Left=�6#   $��	81,44,0,0q�6>    �� TextWrapping$
 Wrap=�6Q   $�� ��6e   $	��Top=�6m   $	��120��6�   �� 5   
   $��Godine��6   $
��Left=�6!   $��	33,81,0,0q�6<   $	��Top=�6O   �� 5   
   -   5        $ 
gidineUnos��5      $
��Left=�6&   $��	86,89,0,0q�6A   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��120��6�   �� 5   
   $	��Pol��6   $
��Left=�6   $��
33,131,0,0q�69   $	��Top=�6M   �� 5   
   -   5        $ polUnos��5      $
��Left=�6#   $��
86,135,0,0q�6>   $
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��120��6�   �� 5   
   $��Vlasnik��6   $
��Left=�6"   $��
288,36,0,0q�6=   $	��Top=�6Q   �� 5   
   -   5         ��Name$ vlasniOdabir��5      $
��Left=�6)   $��
350,37,0,0q�6D   $	��Top=�6X   $	��120��6p    �� DisplayMemberPath$ PunoIme��6|    �� SelectedValuePath$ Id��6�   �� 5   
   $
��Rasa��6   $
��Left=�6   $��
288,89,0,0q�6:   $	��Top=�6N   �� 5   
   -   5        $ 
rasaOdabir��5      $
��Left=�6'   $��
350,94,0,0q�6B   $	��Top=�6V   $	��120��6n   $ Naziv��6z   $ Id��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	psiPrikaz��5         AutoGenerateColumns$ False��6&   $��33,232,0,66q�6B      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Id+  5      $		 Ime��6%   
 62   �� *Ime+  5      $	 RasaId��6%   
 65   �� *RasaId+  5      $	 Godine��6%   
 65   �� *Godine+  5      $		 Pol��6%   
 62   �� *Pol+  5      $	 
IdVlasnika��6%   
 69   �� *
IdVlasnika+5      �� 5   
   -   5         ��Name$ unesiBtn��5      $��Unesi��6#   $
��Left=�63   $��
37,187,0,0q�6N   $	��Top=�6b   6z   �� 5   
   -   5        $ 	izmeniBtn��5      $��Izmeni��6$   $
��Left=�65   $��124,187,0,0q�6P   $	��Top=�6e   6}   �� 5    
   -	   5        $ 	obrisiBtn��5       $��Obrisi��6$   $
��Left=�65   $��227,187,0,0q�6P   $	��Top=�6e   6}   5!      5"      