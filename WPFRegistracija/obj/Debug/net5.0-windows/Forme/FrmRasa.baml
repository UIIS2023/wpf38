   M S B A M L   `   `   `  ����J  FWPFRegistracija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WPFRegistracija.FormeWPFRegistracija.Forme  5   	   #    WPFRegistracija.Forme.FrmRasa   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:WPFRegistracija.Forme     5   	     � Title$  	Unos rase��5   	   $	��243��6   $	��349��6(   .��5	      � $��0,0,17,0q�6   .+�5
   
   �� -   5        $��RasaNazivLabel��5
   l   $��Naziv rase:��6   $
��Left=�6&   $��	30,20,0,0q�6A   $	��Top=�6T   6l   �� 5   
   -   5         ��Name$ unosRase��5      $
��Left=�6$   $��23��6?   $��
120,20,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��	30,51,0,0q�6R   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5        $ 	btnUpdate��5      $��Izmeni��6$   $
��Left=�65   $��
110,51,0,0q�6P   $	��Top=�6d   $��75��6|   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
rasePrikaz��5         AutoGenerateColumns$ False��6'   $��30,82,10,15q�6C      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $ 
Naziv rase��6%    69   �� *Naziv+5      �� 5   
   -   5        $ 	btnDelete��5      $��Obrisi��6$   $
��Left=�65   $��
204,51,0,0q�6P   $	��Top=�6d   $��75��6|   6�   5      5      