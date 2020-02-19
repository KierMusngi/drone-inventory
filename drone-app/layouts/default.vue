<template>
  <v-app class="default-layout">
    <v-navigation-drawer
      v-model="drawer"
      floating
      temporary
      app
      overflow
      dark
    >
      <v-list-item two-line>
        <v-list-item-avatar>
          <v-icon x-large>mdi-account-circle</v-icon>
        </v-list-item-avatar>
        <v-list-item-content>
          <v-list-item-title>Hi User!</v-list-item-title>
          <v-list-item-subtitle>Admin</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>

      <v-divider></v-divider>

      <template>
        <div class="pa-2">
          <v-list dense>
            <v-list-item link @click="goToScan">
              <v-list-item-action>
                <v-icon>mdi-qrcode-scan</v-icon>
              </v-list-item-action>
              <v-list-item-content>
                  <v-list-item-title>QR Scanner</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
            <v-list-item link @click="goToInventory">
              <v-list-item-action>
                <v-icon>mdi-package-variant-closed</v-icon>
              </v-list-item-action>
              <v-list-item-content>
                  <v-list-item-title>Inventory</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </v-list>
        </div>
      </template>


      <template v-slot:append>
        <div class="pa-2">
          <v-list dense>
            <v-list-item link @click="goToLogin">
              <v-list-item-action>
                  <v-icon>mdi-logout</v-icon>
              </v-list-item-action>
              <v-list-item-content>
                  <v-list-item-title>Logout</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </v-list>
        </div>
      </template>
    </v-navigation-drawer>

    <v-app-bar
      clipped-left
      app
    >
      <v-app-bar-nav-icon
        @click.stop="drawer = !drawer"
      />
      <v-toolbar-title>Drone Inventory System</v-toolbar-title>
    </v-app-bar>

    <v-content>
      <nuxt />
    </v-content>
  </v-app>
</template>

<script>
  export default {
    data: () => ({
        drawer: false,
    }),

    methods: {
      goToScan(){
        this.$nuxt.$router.replace({path : '/scan'});
      },
      goToInventory(){
        this.$nuxt.$router.replace({path : '/inventory'});
      },
      async goToLogin(){
        await this.$auth.logout()
      }
    },
  }
</script>

<style scoped>
  /* .default-layout{
    background-image: url('../assets/drone-bg.jpg');
    background-size: cover;
  } */
</style>

