export interface JwtToken {
    accessToken: string;
    expirationTime: Date;
    issuedAt: Date;
}