   M S B A M L   `   `   `  ����K  GZubna ordinacija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Zubna_ordinacija.FormeZubna_ordinacija.Forme  5   	   &     Zubna_ordinacija.Forme.FrmRacuni   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Zubna_ordinacija.Forme     5   	     � Title$  Dodaj/Izmeni račun��5   	   $	��200��6$   $	��300��61   .��5	      � 
�������.+�5
   
   �� $��Nacin placanja: ��6   $
��Left=�6,   $��	29,30,0,0q�6G   $	��Top=�6Z    J� RenderTransformOrigin$ -1.035,-0.927&�6r   �� 5   
   -   5         ��Name$ txtNacinPlacanja��5      $
��Left=�6,   $��
135,31,0,0q�6G    �� TextWrapping$
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $��23��6�   $	��120��6�   �� 5   
   $��Ukupna cena: ��6   $
��Left=�6)   $��	29,60,0,0q�6D   $	��Top=�6W   $ -1.035,-0.927&�6o   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sacuvaj��6%   
�������
��� d �$
��Left=�6i   $��
30,133,0,0q�6�   $��75��6�   $	��Top=�6�   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkazi��6$   
���z���
���  ��$
��Left=�6c   $��180,133,0,0q�6~   $��75��6�   $	��Top=�6�   6�   �� 5   
   -   5        $ txtUkupnaCena��5      $
��Left=�6)   $��
135,61,0,0q�6D   $
 Wrap=�6X   $�� ��6l   $	��Top=�6t   $��23��6�   $	��120��6�   �� 5   
   $��Osiguranje: ��6   $
��Left=�6(   $��	29,91,0,0q�6C   $	��Top=�6V   $ -1.035,-0.927&�6n   �� 5   
   -   5         ��Name$ cbOsiguranje��5      $
��Left=�6)   $��
135,92,0,0q�6D   $	��Top=�6X   $��23��6p   $	��120��6|    �� DisplayMemberPath$ vrstaOsiguranja��6�    �� SelectedValuePath$ osiguranjeID��6�   5      5      