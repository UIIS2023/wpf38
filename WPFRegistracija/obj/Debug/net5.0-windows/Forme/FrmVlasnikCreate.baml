   M S B A M L   `   `   `  ����J  FWPFRegistracija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WPFRegistracija.FormeWPFRegistracija.Forme  5   	   ,    &WPFRegistracija.Forme.FrmVlasnikCreate   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:WPFRegistracija.Forme     5   	     � Title$  Novi vlasnik��5   	   $	��588��6   $
��1000��6+   .��5	      � .+�5
   
   �� $��Ime vlasnika:��6   $
��Left=�6(   $��	26,23,0,0q�6C   $	��Top=�6V   �� 5   
   -   5         ��Name$ imeUnos��5      $
��Left=�6#   $��
121,27,0,0q�6>    �� TextWrapping$
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��120��6�   �� 5   
   $��Prezime vlasnika:��6   $
��Left=�6,   $��	26,72,0,0q�6G   $	��Top=�6Z   �� 5   
   -   5        $ prezimeUnos��5      $
��Left=�6'   $��
131,80,0,0q�6B   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��120��6�   �� 5   
   $��Adresa��6   $
��Left=�6!   $��
37,130,0,0q�6<   $	��Top=�6P   �� 5   
   -   5        $ 
adresaUnos��5      $
��Left=�6&   $��103,138,0,0q�6A   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��120��6�   �� 5   
   $��Telefon:��6   $
��Left=�6#   $��
353,27,0,0q�6>   $	��Top=�6R   �� 5   
   -   5        $ telefonUnos��5      $
��Left=�6'   $��
409,31,0,0q�6B   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��120��6�   �� 5   
   -   5        $ 	emailUnos��5      $
��Left=�6%   $��
409,80,0,0q�6@   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��120��6�   �� 5   
   $��Email:��6   $
��Left=�6!   $��
353,76,0,0q�6<   $	��Top=�6P   �� 5   
   $��JMBG:��6   $
��Left=�6    $��358,129,0,0q�6;   $	��Top=�6P   �� 5   
   -   5        $ JMBGUnos��5      $
��Left=�6$   $��409,130,0,0q�6?   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��120��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ vlasniciPrikaz��5         AutoGenerateColumns$ False��6+   $��26,220,294,112q�6G      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $	 Ime��6%    62   �� *Ime+  5      $ Prezime��6%    66   �� *	Prezime+  5      $ Adresa��6%    65   �� *Adresa+  5      $ Telefon��6%    66   �� *	Telefon+  5      $ Email��6%    64   �� *Email+  5      $
 JMBG��6%    63   �� *JMBG+5       �� 5!   
   -   5        $��Unesi vlasnika��5!      $
��Left=�6*   $��
38,175,0,0q�6E   $	��Top=�6Y   6q   �� 5"   
   -	   5        $��Izmeni vlasnika��5"      $
��Left=�6+   $��152,175,0,0q�6F   $	��Top=�6[   6s   �� 5#   
   -
   5        $��Obrisi vlasnika��5#      $
��Left=�6+   $��290,175,0,0q�6F   $	��Top=�6[   6s   5%      5&      