   M S B A M L   `   `   `  ����K  GZubna ordinacija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Zubna_ordinacija.FormeZubna_ordinacija.Forme  5   	   *    $Zubna_ordinacija.Forme.FrmEvidencije   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Zubna_ordinacija.Forme     5   	     � Title$  Dodaj/Izmeni evidenciju��5   	   $	��250��6)   $	��375��66   .��5	      � 
�������.+�5
   
   �� $+��%Opis trenutnog stanja toka lečenja: ��6   $
��Left=�6@   $��	30,11,0,0q�6[   $	��Top=�6n    J� RenderTransformOrigin$ -1.035,-0.927&�6�   $��48��6�   $	��308��6�   �� 5   
   -   5         ��Name$ txtTokLecenja��5      $
��Left=�6)   $��	30,35,0,0q�6D    �� TextWrapping$
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $��85��6�   $	��308��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sacuvaj��6%   
�������
��� d �$
��Left=�6i   $��
30,168,0,0q�6�   $	��103��6�   $	��Top=�6�   $��23��6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkazi��6$   
���z���
���  ��$
��Left=�6c   $��236,168,0,0q�6~   $	��102��6�   $	��Top=�6�   $��23��6�   �� 5   
   $��Sledeći tretman: ��6   $
��Left=�6-   $��
29,127,0,0q�6H   $	��Top=�6\   $ -1.035,-0.927&�6t   $��31��6�   $	��140��6�   �� 5   
   -   5         ��Name$ 	cbTretman��5      $
��Left=�6&   $��174,130,0,0q�6A   $	��Top=�6V   $��26��6n   $	��164��6z    �� DisplayMemberPath$ vrstaTretmana��6�    �� SelectedValuePath$ 	tretmanID��6�   5      5      