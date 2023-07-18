import { ComponentFixture, TestBed } from '@angular/core/testing';
import { OperacoesComponent } from './operacoes.component';
import { CnabService } from 'src/app/shared/services/cnab.service';
import { of } from 'rxjs';
import { Cnab } from 'src/app/shared/models/cnab';
import { HttpClientModule } from '@angular/common/http';

describe('OperacoesComponent', () => {
  let component: OperacoesComponent;
  let fixture: ComponentFixture<OperacoesComponent>;
  let cnabService: CnabService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientModule],
      declarations: [OperacoesComponent],
      providers: [CnabService]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OperacoesComponent);
    component = fixture.componentInstance;
    cnabService = TestBed.inject(CnabService);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call getAll on cnabService when getAll is called', () => {
    const dataImportacao = '2023-07-17';
    const cnabData: Cnab[] = [
      {
        data_importacao: dataImportacao,
        tipo: '1',
        data: '2023-07-17',
        valor: 100.0,
        cpf: '12345678901',
        cartao: '1111222233334444',
        hora: '12:34:56',
        representante_loja: 'Representante Loja',
        loja: 'Loja'
      }
    ];

    const getAllSpy = spyOn(cnabService, 'getAll').and.returnValue(of(cnabData));

    component.getAll();

    expect(component.operacoes).toEqual(cnabData);
  });
});
