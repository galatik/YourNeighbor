import { AuthModule } from './auth.module';

describe('HomeModule', () => {
  let homeModule: AuthModule;

  beforeEach(() => {
    homeModule = new AuthModule();
  });

  it('should create an instance', () => {
    expect(homeModule).toBeTruthy();
  });
});
