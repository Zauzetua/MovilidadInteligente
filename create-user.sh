#!/bin/bash

echo "Esperando a Keycloak..."

until /opt/keycloak/bin/kcadm.sh config credentials \
  --server http://localhost:8080 \
  --realm master \
  --user admin \
  --password admin > /dev/null 2>&1
do
  sleep 5
done

echo "Keycloak listo"

REALM_NAME="MovilidadInteligente"

echo "Buscando usuario profesor..."

USER_ID=$(/opt/keycloak/bin/kcadm.sh get users \
  -r $REALM_NAME \
  -q username=profesor \
  --fields id \
  --format csv 2>/dev/null)

if [ -z "$USER_ID" ]; then

  echo "Usuario no existe, creando..."

  /opt/keycloak/bin/kcadm.sh create users \
    -r $REALM_NAME \
    -s username=profesor \
    -s enabled=true \
    -s email=profesor@movilidad.local \
    -s firstName=Profesor \
    -s lastName=Demo \
    -s emailVerified=true

  /opt/keycloak/bin/kcadm.sh set-password \
    -r $REALM_NAME \
    --username profesor \
    --new-password 1234

  echo "Usuario creado"

else

  echo "Usuario ya existe"

fi

echo "Proceso terminado"